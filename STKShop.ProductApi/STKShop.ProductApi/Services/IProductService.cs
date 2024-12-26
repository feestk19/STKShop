#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 25/12/2024
 MANUTENÇÃO: Implementação inicial da interface IProductService
 */

/*
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Ajuste em nome de métodos
 */
#endregion

using STKShop.ProductApi.DTOs;

namespace STKShop.ProductApi.Services;

/// <summary>
/// Interface IProductService
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Resgata todos os produtos
    /// </summary>
    /// <returns>Lista de todas os produtos</returns>
    Task<IEnumerable<ProductDTO>> GetProducts();

    /// <summary>
    /// Resgata o produto pelo ID
    /// </summary>
    /// <param name="id">ID da produto</param>
    /// <returns>produto com o respectivo ID</returns>
    Task<ProductDTO> GetproductById(int id);

    /// <summary>
    /// Adiciona um novo produto
    /// </summary>
    /// <param name="productDTO">Objeto do tipo productDTO</param>
    /// <returns>produto criado</returns>
    Task AddProduct(ProductDTO productDTO);

    /// <summary>
    /// Atualiza um produto
    /// </summary>
    /// <param name="productDTO">Objeto do tipo productDTO</param>
    /// <returns>Produto atualizado</returns>
    Task UpdateProduct(ProductDTO productDTO);

    /// <summary>
    /// Exclui um produto
    /// </summary>
    /// <param name="id">ID do produto</param>
    /// <returns>Produto excluído</returns>
    Task RemoveProduct(int id);
}
