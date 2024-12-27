#region Comentários de Manutenção

/*------------------------------------------
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Implementação inicial
 -----------------------------------------*/

#endregion

using STKShop.Web.Models;

namespace STKShop.Web.Services.Contracts;

/// <summary>
/// Interface ICategoryService
/// </summary>
public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllCategories();
}
