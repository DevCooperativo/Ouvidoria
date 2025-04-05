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

    public Task CreateAsync(RegistroDTO denuncia)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RegistroDTO> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RegistroDTO> GetAllVisible()
    {
        throw new NotImplementedException();
    }

    public Task<RegistroDTO> GetDTOByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(RegistroDTO denuncia)
    {
        throw new NotImplementedException();
    }
}