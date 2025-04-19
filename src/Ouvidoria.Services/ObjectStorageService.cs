using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Ouvidoria.Infrastructure.ObjectStorage;
using Microsoft.Extensions.Options;
using Ouvidoria.Domain.Exceptions;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;

namespace Ouvidoria.Services;

public class ObjectStorageService : IObjectStorageService
{

    private readonly ObjectStorageProviderSettings _storageProvider;

    public ObjectStorageService(IOptions<ObjectStorageProviderSettings> storageProvider)
    {
        _storageProvider = storageProvider.Value;
    }

    public async Task<string> UploadFileAsync(ArquivoDTO arquivoDTO)
    {
        try
        {
            EntityException.When(!ValidateFileExtension(arquivoDTO.TipoArquivo), "O tipo de arquivo é inválido.");
            AmazonS3Client s3Client = new(_storageProvider.AccessKey, _storageProvider.SecretKey, new AmazonS3Config
            {
                ServiceURL = _storageProvider.ServiceUrl,
                ForcePathStyle = true,
                UseHttp = true
            });

            Guid guid = Guid.NewGuid();


            TransferUtility fileTransferUtility = new(s3Client);

            ListObjectsRequest listRequest = new() { BucketName = _storageProvider.Bucket };

            ListObjectsResponse listResponse = await s3Client.ListObjectsAsync(listRequest);


            byte[] finalBytes = [];
            string fileExtension = arquivoDTO.TipoArquivo;
            finalBytes = arquivoDTO.Bytes;
            string newFileName = $"{guid}.{fileExtension}";
            bool objectExists = listResponse.S3Objects.Any(x => x.Key.Equals(newFileName, StringComparison.CurrentCultureIgnoreCase));
            EntityException.When(objectExists, $"Objeto '{newFileName}' já existe no servidor '{_storageProvider.Bucket}'.");

            using (MemoryStream fileStream = new(finalBytes))
            {
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    BucketName = _storageProvider.Bucket,
                    Key = newFileName,
                    InputStream = fileStream,
                    CannedACL = S3CannedACL.PublicRead
                };
                await fileTransferUtility.UploadAsync(uploadRequest);
            }
            ;

            var getObjectMetadataRequest = new GetObjectMetadataRequest
            {
                BucketName = _storageProvider.Bucket,
                Key = newFileName
            };

            GetObjectMetadataResponse metadataResponse = await s3Client.GetObjectMetadataAsync(getObjectMetadataRequest);


            return newFileName;
        }
        catch (AmazonS3Exception)
        {
            throw new AmazonS3Exception("Não foi possível acessar o provedor de armazenamento. Se o erro persistir contate o suporte.");
        }
        catch (EntityException ex)
        {
            throw new EntityException(ex.Message);
        }
        catch (Exception)
        {
            throw new Exception("Algo deu errado. Se o erro persistir contate o suporte.");
        }
    }

    public string GetFileUrlAsync(string fileName)
    {
        return $"https://s3.devcoop.com.br/{_storageProvider.Bucket}/{fileName}";
    }

    public async Task DeleteFileAsync(string fileName)
    {
        try
        {
            AmazonS3Client s3Client = new(_storageProvider.AccessKey, _storageProvider.SecretKey, new AmazonS3Config
            {
                ServiceURL = _storageProvider.ServiceUrl,
                ForcePathStyle = true,
                UseHttp = true
            });
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _storageProvider.Bucket,
                Key = fileName
            };
            await s3Client.DeleteObjectAsync(deleteObjectRequest);
        }
        catch (AmazonS3Exception)
        {
            throw new AmazonS3Exception("Não foi possível acessar o provedor de armazenamento. Se o erro persistir contate o suporte.");
        }
        catch (EntityException ex)
        {
            throw new EntityException(ex.Message);
        }
        catch (Exception)
        {
            throw new Exception("Algo deu errado. Se o erro persistir contate o suporte.");
        }
    }

    private static bool ValidateFileExtension(string extension)
    {
        List<string> validExtensions = ["png", "jpg", "jpeg", "jfif", "webp", "zip", "7z", "rar", "mp4", "avi", "ogg", "pdf", "docx", "doc", "txt"];
        return validExtensions.Contains(extension);
    }
}
