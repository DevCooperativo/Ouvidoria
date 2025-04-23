
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Exceptions;

namespace Ouvidoria.Domain.Models;
public class Registro : EntidadeBase
{
    private string _tipo { get; set; } = string.Empty;
    public string Tipo
    {
        get => _tipo;
        private set
        {
            EntityException.When(value.Length > 40, "O valor deve ter no máximo 40 caracters");
            EntityException.When(string.IsNullOrEmpty(value), "Tipo é um campo obrigatório");
            _tipo = value;
        }
    }

    public bool IsAnonima { get; private set; } = false;

    private string _titulo { get; set; } = string.Empty;
    public string Titulo
    {
        get => _titulo;
        private set
        {
            EntityException.When(value.Length > 80, "O valor deve ter no máximo 80 caracters");
            EntityException.When(string.IsNullOrEmpty(value), "Título é um campo obrigatório");
            _titulo = value;
        }
    }

    private string _descricao { get; set; } = string.Empty;
    public string Descricao
    {
        get => _descricao;
        private set
        {
            EntityException.When(value.Length > 400, "O valor deve ter no máximo 400 caracters");
            EntityException.When(string.IsNullOrEmpty(value), "Descrição é um campo obrigatório");
            _descricao = value;
        }
    }
    public TipoRegistroEnum TipoRegistro { get; private set; }
    public StatusEnum Status { get; private set; }
    public Cidadao? Autor { get; private set; }
    public int? AutorId { get; private set; }
    public Entidade? Alvo { get; private set; }
    public int? AlvoId { get; private set; }
    public Administrador? Administrador { get; private set; } = default!;
    public int? AdministradorId { get; private set; }
    private List<HistoricoRegistro> _historico = [];
    public IReadOnlyCollection<HistoricoRegistro> Historico => _historico.AsReadOnly();
    private List<Arquivo> _arquivos = [];
    public IReadOnlyCollection<Arquivo> Arquivos => _arquivos.AsReadOnly();
    protected Registro() { }


    public Registro(string tipo, bool isAnonima, string titulo, string descricao, TipoRegistroEnum tipoRegistro, StatusEnum status, Cidadao? autor, Administrador? administrador) : base()
    {
        Tipo = tipo;
        IsAnonima = isAnonima;
        Titulo = titulo;
        Descricao = descricao;
        Status = status;
        TipoRegistro = tipoRegistro;
        if (autor is not null)
        {
            Autor = autor;
            AutorId = autor.Id;
        }
        AddHistorico(StatusEnum.Pendente, "Registro criado no sistema");
        if(administrador is not null){
            Administrador=administrador;
            AdministradorId=administrador.Id;
        }
    }

    public Registro(string tipo, bool isAnonima, string titulo, string descricao, TipoRegistroEnum tipoRegistro, StatusEnum status) : base()
    {
        Tipo = tipo;
        IsAnonima = isAnonima;
        Titulo = titulo;
        Descricao = descricao;
        Status = status;
        TipoRegistro = tipoRegistro;
        AddHistorico(StatusEnum.Pendente, "Registro criado no sistema");

    }

    public void Update(string tipo, string titulo, string descricao, TipoRegistroEnum tipoRegistro, StatusEnum status, Cidadao? autor, Administrador administrador)
    {
        Tipo = tipo;
        Titulo = titulo;
        Descricao = descricao;
        TipoRegistro = tipoRegistro;
        if (autor is not null)
        {
            Autor = autor;
            AutorId = autor.Id;
        }
        Administrador = administrador;
        AdministradorId = administrador.Id;

    }

    public void AtualizarAlvo(Entidade alvo)
    {
        Alvo = alvo;
        AlvoId = alvo.Id;
    }

    public void AddHistorico(StatusEnum status, string feedback)
    {
        _historico.Add(new HistoricoRegistro(status, feedback, this));
        Status = status;
    }

    public void AlterarStatus(StatusEnum status)
    {
        Status = status;
    }

    public void AdicionarArquivo(Arquivo arquivo)
    {
        _arquivos.Add(arquivo);
    }

}
