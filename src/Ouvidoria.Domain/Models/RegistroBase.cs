
using Ouvidoria.Domain.Enums;

namespace Ouvidoria.Domain.Models;
public class Registro : EntidadeBase
{
    public string Tipo { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;
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


    public Registro(string tipo, string descricao, TipoRegistroEnum tipoRegistro, StatusEnum status, Cidadao? autor, Administrador administrador) : base()
    {
        Tipo = tipo;
        Descricao = descricao;
        Status = status;
        TipoRegistro = tipoRegistro;
        if (autor is not null)
        {
            Autor = autor;
            AutorId = autor.Id;
        }
        Administrador = administrador;
        AdministradorId = administrador.Id;

    }

    public void Update(string empty, string descricao, string status)
    {

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
