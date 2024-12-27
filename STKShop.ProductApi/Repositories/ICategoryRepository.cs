#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da interface ICategoryRepository
 */
#endregion

using STKShop.ProductApi.Models;

namespace STKShop.ProductApi.Repositories;

/// <summary>
/// Interface de Categoria
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Pega todas as Categorias
    /// </summary>
    /// <returns>Todas as categorias cadastradas</returns>
    Task<IEnumerable<Category>> GetAll();

    /// <summary>
    /// Pega todas as Categorias com os produtos
    /// </summary>
    /// <returns>Todas as Categorias com os respectivos produtos</returns>
    Task<IEnumerable<Category>> GetCategoriesProducts();

    /// <summary>
    /// Pega uma categoria pelo Id
    /// </summary>
    /// <param name="id">Id da Categoria</param>
    /// <returns>Categoria correspondente ao ID</returns>
    Task<Category> GetById(int id);

    /// <summary>
    /// Cria uma nova categoria
    /// </summary>
    /// <param name="category">Objeto do tipo Category</param>
    /// <returns>Categoria criada</returns>
    Task<Category> Create(Category category);

    /// <summary>
    /// Atualiza uma categoria
    /// </summary>
    /// <param name="category">Objeto do tipo Category</param>
    /// <returns>Categoria atualizada</returns>
    Task<Category> Update(Category category);

    /// <summary>
    /// Exclui uma categoria
    /// </summary>
    /// <param name="id">ID da categoria a ser excluída</param>
    /// <returns>Categoria excluída</returns>
    Task<Category> Delete(int id);
}
