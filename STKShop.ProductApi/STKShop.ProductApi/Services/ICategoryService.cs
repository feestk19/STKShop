#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 25/12/2024
 MANUTENÇÃO: Implementação inicial da interface ICategoryService
 */

#endregion

using STKShop.ProductApi.DTOs;

namespace STKShop.ProductApi.Services;

/// <summary>
/// Interface ICategoryService
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Resgata todas as categorias
    /// </summary>
    /// <returns>Lista de todas as categorias</returns>
    Task<IEnumerable<CategoryDTO>> GetCategories();

    /// <summary>
    /// Resgata todas as categorias com os respectivos produtos
    /// </summary>
    /// <returns>Lista com todas as categorias e produtos</returns>
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();

    /// <summary>
    /// Resgata a categoria pelo ID
    /// </summary>
    /// <param name="id">ID da categoria</param>
    /// <returns>Categoria com o respectivo ID</returns>
    Task<CategoryDTO> GetCategoryById(int id);

    /// <summary>
    /// Adiciona uma nova categoria
    /// </summary>
    /// <param name="categoryDTO">Objeto do tipo CategoryDTO</param>
    /// <returns>Categoria criada</returns>
    Task AddCategory(CategoryDTO categoryDTO);

    /// <summary>
    /// Atualiza uma categoria
    /// </summary>
    /// <param name="categoryDTO">Objeto do tipo CategoryDTO</param>
    /// <returns>Categoria atualizada</returns>
    Task UpdateCategory(CategoryDTO categoryDTO);

    /// <summary>
    /// Exclui uma categoria
    /// </summary>
    /// <param name="id">ID da categoria</param>
    /// <returns>Categoria excluída</returns>
    Task RemoveCategory(int id);
}
