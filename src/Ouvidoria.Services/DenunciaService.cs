using Ouvidoria.DTO;
using Ouvidoria.Interfaces;

namespace Ouvidoria.Services;

public class DenunciaService : IDenunciaService
{

    public DenunciaService() { }

    public Task ChangeVisibility(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(RegistroBaseDTO denuncia)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RegistroBaseDTO> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RegistroBaseDTO> GetAllVisible()
    {
        throw new NotImplementedException();
    }

    public Task<RegistroBaseDTO> GetDTOByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(RegistroBaseDTO denuncia)
    {
        throw new NotImplementedException();
    }
}