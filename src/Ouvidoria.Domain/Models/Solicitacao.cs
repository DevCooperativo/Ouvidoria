
using Ouvidoria.Domain.Abstractions;
using Ouvidoria.Domain.Enums;

namespace Ouvidoria.Domain.Models;
public class Solicitacao : RegistroBase
{
    // Referente à solicitação ou denuncia. Sobre o tema
    protected Solicitacao() { }


    public Solicitacao(string tipo, string descricao, StatusEnum status, Cidadao? autor, Administrador administrador) : base(tipo, descricao, status, autor, administrador)
    {

    }


}
