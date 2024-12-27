#region Comentários de Manutenção

/*------------------------------------------
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Implementação inicial
 -----------------------------------------*/

#endregion

using STKShop.Web.Models;

namespace STKShop.Web.Services.Contracts;

/// <summary>
/// Interface IProductService
/// </summary>
public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();
    Task<ProductViewModel> FindProductById(int id);
    Task<ProductViewModel> CreateProduct(ProductViewModel productVM);
    Task<ProductViewModel> UpdateProduct(ProductViewModel productVM);
    Task<bool> DeleteProductById(int id);

}
