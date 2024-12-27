#region Comentários de Manutenção

/*------------------------------------------
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Implementação inicial
 -----------------------------------------*/
/*------------------------------------------
 DATA_ATUALIZAÇÃO: 27/12/2024
 MANUTENÇÃO: Adicionado summaries e métodos de alteração e exclusão
 -----------------------------------------*/

#endregion

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using STKShop.Web.Models;
using STKShop.Web.Services.Contracts;

namespace STKShop.Web.Controllers;

/// <summary>
/// Controller de Produtos
/// </summary>
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    /// <summary>
    /// Resgata todos os produtos
    /// </summary>
    /// <returns>Todos os produtos disponíveis</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
    {
        var result = await _productService.GetAllProducts();

        if (result == null)
            return View("Error");

        return View(result);
    }

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    /// <returns>Produto criado</returns>
    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(), "CategoryId", "Name");

        return View();
    }

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    /// <param name="productVM">Objeto View Model de produto</param>
    /// <returns>Produto criado</returns>
    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductViewModel productVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _productService.CreateProduct(productVM);

            if (result != null)
                return RedirectToAction(nameof(Index));

        }
        else
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(), "CategoryId", "Name");
        }

        return View(productVM);
    }

    /// <summary>
    /// Altera um produto
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>Produto alterado</returns>
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(), "CategoryId", "Name");

        var result = await _productService.FindProductById(id);

        if (result is null)
            return View("Error");

        return View(result);
    }

    /// <summary>
    /// Altera um produto
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>Produto alterado</returns>
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(ProductViewModel productVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _productService.UpdateProduct(productVM);

            if (result != null)
                return RedirectToAction(nameof(Index));
        }

        return View(productVM);
    }

    /// <summary>
    /// Resgata o produto que será excluído
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>Produto que será excluído</returns>
    [HttpGet]
    public async Task<ActionResult<ProductViewModel>> DeleteProduct(int id)
    {
        var result = await _productService.FindProductById(id);

        if (result is null)
            return View("Error");

        return View(result);
    }

    /// <summary>
    /// Exclui um produto
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>True ou False dependendo do resultado da exclusão do produto</returns>
    [HttpPost(), ActionName("DeleteProduct")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _productService.DeleteProductById(id);

        if (!result)
            return View("Error");

        return RedirectToAction("Index");
    }
}
