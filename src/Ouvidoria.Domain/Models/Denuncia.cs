
using Ouvidoria.Domain.Enums;

namespace Ouvidoria.Domain.Models;
public class Denuncia : RegistroBase
{
    // Referente à solicitação ou denuncia. Sobre o tema
    protected Denuncia() { }


    public Denuncia(string tipo, string descricao, StatusEnum status, Cidadao? autor, Administrador administrador) : base(tipo, descricao, status, autor, administrador)
    {


    }

}
