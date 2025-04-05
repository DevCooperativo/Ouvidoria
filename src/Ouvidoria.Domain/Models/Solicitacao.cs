
using Ouvidoria.Domain.Abstractions;

namespace Ouvidoria.Domain.Models;
public class Solicitacao : RegistroBase
{
    // Referente à solicitação ou denuncia. Sobre o tema
    protected Solicitacao() { }


    public Solicitacao(string tipo, string descricao, string status, Cidadao? autor, Administrador administrador) : base(tipo, descricao, status, autor, administrador)
    {

    }


}
