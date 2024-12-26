#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 25/12/2024
 MANUTENÇÃO: Implementação inicial da classe CategoriesController
 */

/*
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Adicionado métodos na Controller
 */

#endregion

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STKShop.ProductApi.DTOs;
using STKShop.ProductApi.Services;

namespace STKShop.ProductApi.Controllers;

/// <summary>
/// Classe CategoriesController
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Resgata todas as categorias
    /// </summary>
    /// <returns>Todas as Categorias disponíveis</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categoriesDTO = await _categoryService.GetCategories();
        if(categoriesDTO is null)
            return NotFound("Categorias não encontradas."); 

        return Ok(categoriesDTO);
    }

    /// <summary>
    /// Resgata todas as categorias com os respectivos produtos
    /// </summary>
    /// <returns>Todas as categorias com os produtos</returns>
    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
    {
        var categoriesDTO = await _categoryService.GetCategoriesProducts();
        if (categoriesDTO is null)
            return NotFound("Categorias não encontradas.");

        return Ok(categoriesDTO);
    }

    /// <summary>
    /// Resgata uma categoria pelo id
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <returns>Categoria conforme o ID</returns>
    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
    {
        var categoriesDTO = await _categoryService.GetCategoryById(id);
        if (categoriesDTO is null)
            return NotFound("Categoria não encontrada.");

        return Ok(categoriesDTO);
    }

    /// <summary>
    /// Adiciona uma nova categoria
    /// </summary>
    /// <param name="categoryDTO">Objeto que contém a categoria a ser cadastrada</param>
    /// <returns>Categoria registrada</returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return BadRequest("Dados inválidos");

        await _categoryService.AddCategory(categoryDTO);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.CategoryId }, categoryDTO);
    }

    /// <summary>
    /// Altera uma categoria
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <param name="categoryDTO">Objeto que contém a categoria a ser alterada</param>
    /// <returns>Categoria Alterada</returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.CategoryId)
            return BadRequest("Id da categoria enviada é diferente da categoria a ser alterada.");

        if (categoryDTO is null)
            return BadRequest("Categoria não encontrada ou inválida.");

        await _categoryService.UpdateCategory(categoryDTO);

        return Ok(categoryDTO);
    }

    /// <summary>
    /// Exclui uma categoria
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <returns>Categoria que foi excluída</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var categoryDto = await _categoryService.GetCategoryById(id);
        if (categoryDto is null)
            return NotFound("Categoria não encontrada.");

        await _categoryService.RemoveCategory(id);

        return Ok(categoryDto);
    }
}
