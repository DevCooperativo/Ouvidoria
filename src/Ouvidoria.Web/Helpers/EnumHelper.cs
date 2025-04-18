using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;

namespace Ouvidoria.Web.Helpers;

public static class EnumHelper
{

    /// <summary>
    /// Recupera uma instância de SelectList a partir de um enum
    /// </summary>
    /// <typeparam name="T">Enum</typeparam>
    /// <returns>SelectList</returns>
    public static IEnumerable<SelectListItem> RecuperarSelectListItemEnum<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(f =>
            {
                bool isPendente = f.GetDisplayName() == "Pendente";
                return new SelectListItem
                {
                    Value = f.ToString(),
                    Text = f.GetDisplayName(),
                    Disabled = isPendente
                };
            });;
    }
}
