using Ouvidoria.Domain.Exceptions;

namespace Ouvidoria.Domain.Models;

public class Notificacao : EntidadeBase
{
    public string Titulo { get; private set; } = string.Empty;
    public string Mensagem { get; private set; } = string.Empty;
    public Cidadao Cidadao { get; private set; } = default!;
    public int CidadaoId { get; private set; }
    public RegistroBase Registro { get; private set; } = default!;
    public int RegistroId { get; private set; }


    protected Notificacao() { }
    public Notificacao(string mensagem, Cidadao cidadao, RegistroBase registro) : base()
    {
        Mensagem = mensagem;
        Cidadao = cidadao;
        CidadaoId = cidadao.Id;
        Registro = registro;
        RegistroId = registro.Id;
    }
}
