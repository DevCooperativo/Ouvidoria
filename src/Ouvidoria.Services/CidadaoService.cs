using System.Security.Claims;
using Ouvidoria.Domain;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Domain.Models;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;

namespace Ouvidoria.Services;

public class CidadaoService : ICidadaoService
{
    private readonly ICidadaoRepository _repositorio;
    private readonly IUnitOfWork _unitOfWork;
    public CidadaoService(IUnitOfWork unitOfWork, ICidadaoRepository repositorio)
    {
        _repositorio = repositorio;
        _unitOfWork = unitOfWork;
    }

    public async Task<CidadaoDTO> GetCidadaoByClaimsAsync(ClaimsPrincipal claimsPrincipal)
    {
        Cidadao cidadao = await _repositorio.GetCidadaoByClaimsAsync(claimsPrincipal) ?? throw new Exception("Não foi possível encontrar um cidadão");
        return new CidadaoDTO(cidadao);
    }
    public async Task CreateAsync(CidadaoDTO cidadao)
    {
        ArgumentNullException.ThrowIfNull(cidadao);

        bool exists = _repositorio.GetAllReadOnly().Any(x => x.Email.Equals(cidadao.Email, StringComparison.InvariantCultureIgnoreCase));
        if (exists)
            throw new ArgumentException("Esse e-mail está em uso");

        Cidadao newCidadao = new(cidadao.Nome, cidadao.Email, cidadao.Cpf, cidadao.Telefone, cidadao.Endereco, cidadao.Sexo, cidadao.DataNascimento);

        var cidadaoSaved = _repositorio.Add(newCidadao);

        _ = await _unitOfWork.Commit();
    }

    public IEnumerable<CidadaoDTO> GetAllAsync()
    {
        var cidadaoes = _repositorio.GetAllReadOnly();
        return cidadaoes.Select(x => new CidadaoDTO(x)) ?? [];
    }

    public async Task<CidadaoDTO> GetDTOByEmailAsync(string email)
    {
        Cidadao cidadao = await _repositorio.GetByEmailAsync(email) ?? throw new ArgumentException("Email não encontrado");

        return new CidadaoDTO(cidadao);
    }

    public async Task<CidadaoDTO> GetDTOByIdAsync(int id)
    {
        Cidadao cidadao = await _repositorio.GetByIdAsync(id) ?? throw new ArgumentException("Cidadao não encontrado");

        return new CidadaoDTO(cidadao);
    }

    public async Task UpdateAsync(CidadaoDTO cidadao)
    {
        ArgumentNullException.ThrowIfNull(cidadao);

        bool exists = _repositorio.GetAllReadOnly().Any(x => x.Email.Equals(cidadao.Email, StringComparison.InvariantCultureIgnoreCase) && x.Id != cidadao.Id);
        if (exists)
            throw new ArgumentException("Email já cadastrado");

        Cidadao currentCidadao = await _repositorio.GetByIdAsync(cidadao.Id) ?? throw new Exception("Não foi possível encontrar a cor");

        currentCidadao.Update(cidadao.Nome, cidadao.Email, cidadao.Cpf, cidadao.Telefone, cidadao.Endereco, cidadao.Sexo, cidadao.DataNascimento);

        var cidadaoSaved = _repositorio.Update(currentCidadao);

        _ = await _unitOfWork.Commit();
    }
}
