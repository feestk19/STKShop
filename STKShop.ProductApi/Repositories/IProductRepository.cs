#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da interface IProductRepository
 */
#endregion

using STKShop.ProductApi.Models;

namespace STKShop.ProductApi.Repositories;

/// <summary>
/// Interface IProductRepository
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Pega todas as Produtos
    /// </summary>
    /// <returns>Todas as Produtos cadastrados</returns>
    Task<IEnumerable<Product>> GetAll();

    /// <summary>
    /// Pega uma Produto pelo Id
    /// </summary>
    /// <param name="id">Id da Produto</param>
    /// <returns>Produto correspondente ao ID</returns>
    Task<Product> GetById(int id);

    /// <summary>
    /// Cria uma nova Produto
    /// </summary>
    /// <param name="category">Objeto do tipo Category</param>
    /// <returns>Produto criada</returns>
    Task<Product> Create(Product product);

    /// <summary>
    /// Atualiza uma Produto
    /// </summary>
    /// <param name="category">Objeto do tipo Category</param>
    /// <returns>Produto atualizada</returns>
    Task<Product> Update(Product product);

    /// <summary>
    /// Exclui uma Produto
    /// </summary>
    /// <param name="id">ID da Produto a ser excluído</param>
    /// <returns>Produto excluída</returns>
    Task<Product> Delete(int id);
}
