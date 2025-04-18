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
    public static SelectList RecuperarSelectListItemEnum<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(e => new
            {
                ID = Convert.ToInt32(e),
                Name = e.GetDisplayName()
            });

        return new SelectList(values, "ID", "Name");
    }
}
