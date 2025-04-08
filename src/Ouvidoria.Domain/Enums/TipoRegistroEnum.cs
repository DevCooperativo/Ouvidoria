using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Domain.Enums;

public enum TipoRegistroEnum
{
    [Display(Name = "Denúncia")]
    denuncia = 1,

    [Display(Name = "Solicitação")]
    solicitacao = 2
}
