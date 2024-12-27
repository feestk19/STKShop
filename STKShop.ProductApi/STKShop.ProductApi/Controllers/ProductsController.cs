#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Implementação inicial da classe ProductsController
 */

/*------------------------------------------
 DATA_ATUALIZAÇÃO: 27/12/2024
 MANUTENÇÃO: Adicionado summaries e métodos de alteração e exclusão
 -----------------------------------------*/
#endregion

using Microsoft.AspNetCore.Mvc;
using STKShop.ProductApi.DTOs;
using STKShop.ProductApi.Services;

namespace STKShop.ProductApi.Controllers;

/// <summary>
/// Products Controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Resgata todos os produtos
    /// </summary>
    /// <returns>Todos os produtos disponíveis</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var productsDTO = await _productService.GetProducts();
        if (productsDTO is null)
            return NotFound("Produtos não encontrados.");

        return Ok(productsDTO);
    }

    /// <summary>
    /// Resgata um produto pelo id
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>produto conforme o ID</returns>
    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
    {
        var productsDTO = await _productService.GetproductById(id);
        if (productsDTO is null)
            return NotFound("produto não encontrado.");

        return Ok(productsDTO);
    }

    /// <summary>
    /// Adiciona um nova produto
    /// </summary>
    /// <param name="categoryDTO">Objeto que contém a produto o ser cadostrado</param>
    /// <returns>produto registrado</returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
            return BadRequest("Dados inválidos");

        await _productService.AddProduct(productDTO);

        return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
    }

    /// <summary>
    /// Altera um produto
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <param name="categoryDTO">Objeto que contém o produto a ser alterado</param>
    /// <returns>produto Alterado</returns>
    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
            return BadRequest("Dados inválido");

        await _productService.UpdateProduct(productDTO);

        return Ok(productDTO);
    }

    /// <summary>
    /// Exclui um produto
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>produto que foi excluído</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var productDTO = await _productService.GetproductById(id);
        if (productDTO is null)
            return NotFound("Produto não encontrado.");

        await _productService.RemoveProduct(id);

        return Ok(productDTO);
    }
}
