
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Exceptions;

namespace Ouvidoria.Domain.Models;
public class Registro : EntidadeBase
{
    private string _descricao = string.Empty;
    public string Descricao
    {
        get => _descricao;
        private set
        {
            EntityException.When(value.Length > 500, "A descrição não pode passar de 500 caracteres.");
            _descricao = value;
        }
    }
    public TipoRegistroEnum TipoRegistro { get; private set; }
    public StatusEnum Status { get; private set; }
    public Cidadao? Autor { get; private set; }
    public int AutorId { get; private set; }
    public Entidade? Alvo { get; private set; }
    public int? AlvoId { get; private set; }
    public Administrador Administrador { get; private set; } = default!;
    public int AdministradorId { get; private set; }
    private List<HistoricoRegistro> _historico = [];
    public IReadOnlyCollection<HistoricoRegistro> Historico => _historico.AsReadOnly();
    private List<Arquivo> _arquivos = [];
    public IReadOnlyCollection<Arquivo> Arquivos => _arquivos.AsReadOnly();
    protected Registro() { }


    public Registro(string descricao, TipoRegistroEnum tipoRegistro, Cidadao? autor, Administrador administrador) : base()
    {
        Descricao = descricao;
        Status = StatusEnum.Pendente;
        TipoRegistro = tipoRegistro;
        if (autor is not null)
        {
            Autor = autor;
            AutorId = autor.Id;
        }
        Administrador = administrador;
        AdministradorId = administrador.Id;

    }

    public void Update(string descricao, StatusEnum status, Administrador administrador)
    {
        Descricao = descricao;
        Status = status;
        Administrador = administrador;
    }

    public void AtualizarAlvo(Entidade alvo)
    {
        Alvo = alvo;
        AlvoId = alvo.Id;
    }

    public void addHistorico(HistoricoRegistro historico)
    {
        _historico.Add(historico);
    }

    public void AlterarStatus(StatusEnum status)
    {
        Status = status;
    }

}
