#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 25/12/2024
 MANUTENÇÃO: Implementação inicial da classe CategoryService
 */

/*
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Correção no método de obter categoria por ID
 */
#endregion

using AutoMapper;
using STKShop.ProductApi.DTOs;
using STKShop.ProductApi.Models;
using STKShop.ProductApi.Repositories;

namespace STKShop.ProductApi.Services;

/// <summary>
/// Classe do Serviço CategoryService
/// </summary>
public class CategoryService : ICategoryService
{

    #region DI e Declarações
    private readonly ICategoryRepository _categoryRep;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRep, IMapper mapper)
    {
        _categoryRep = categoryRep;
        _mapper = mapper;
    }
    #endregion

    #region Métodos
    /// <summary>
    /// Resgata todas as categorias
    /// </summary>
    /// <returns>Lista de todas as categorias</returns>
    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRep.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    /// <summary>
    /// Resgata todas as categorias com os respectivos produtos
    /// </summary>
    /// <returns>Lista com todas as categorias e produtos</returns>
    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntity = await _categoryRep.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    /// <summary>
    /// Resgata a categoria pelo ID
    /// </summary>
    /// <param name="id">ID da categoria</param>
    /// <returns>Categoria com o respectivo ID</returns>
    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoriesEntity = await _categoryRep.GetById(id);
        return _mapper.Map<CategoryDTO>(categoriesEntity);
    }

    /// <summary>
    /// Adiciona uma nova categoria
    /// </summary>
    /// <param name="categoryDTO">Objeto do tipo CategoryDTO</param>
    /// <returns>Categoria criada</returns>
    public async Task AddCategory(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRep.Create(categoryEntity);
        categoryDTO.CategoryId = categoryEntity.CategoryId;
    }

    /// <summary>
    /// Atualiza uma categoria
    /// </summary>
    /// <param name="categoryDTO">Objeto do tipo CategoryDTO</param>
    /// <returns>Categoria atualizada</returns>
    public async Task UpdateCategory(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRep.Update(categoryEntity);
    }

    /// <summary>
    /// Exclui uma categoria
    /// </summary>
    /// <param name="id">ID da categoria</param>
    /// <returns>Categoria excluída</returns>
    public async Task RemoveCategory(int id)
    {
        var categoryEntity = _categoryRep.GetById(id).Result;
        await _categoryRep.Delete(categoryEntity.CategoryId);
    }
    #endregion
}
