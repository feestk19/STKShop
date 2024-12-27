#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe CategoryRepository
 */
#endregion

using Microsoft.EntityFrameworkCore;
using STKShop.ProductApi.Context;
using STKShop.ProductApi.Models;

namespace STKShop.ProductApi.Repositories;

/// <summary>
/// Classe CategoryRepository
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    #region Declarações e DI
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Métodos
    /// <summary>
    /// Pega todas as Categorias
    /// </summary>
    /// <returns>Todas as categorias cadastradas</returns>
    public async Task<IEnumerable<Category>> GetAll()
    {
       return await _context.Categories.ToListAsync();
    }

    /// <summary>
    /// Pega todas as Categorias com os produtos
    /// </summary>
    /// <returns>Todas as Categorias com os respectivos produtos</returns>
    public async Task<IEnumerable<Category>> GetCategoriesProducts()
    {
        return await _context.Categories.Include(c => c.Products).ToListAsync();
    }

    /// <summary>
    /// Pega uma categoria pelo Id
    /// </summary>
    /// <param name="id">Id da Categoria</param>
    /// <returns>Categoria correspondente ao ID</returns>
    public async Task<Category> GetById(int id)
    {
        return await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Cria uma nova categoria
    /// </summary>
    /// <param name="category">Objeto do tipo Category</param>
    /// <returns>Categoria criada</returns>
    public async Task<Category> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    /// <summary>
    /// Atualiza uma categoria
    /// </summary>
    /// <param name="category">Objeto do tipo Category</param>
    /// <returns>Categoria atualizada</returns>
    public async Task<Category> Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }

    /// <summary>
    /// Exclui uma categoria
    /// </summary>
    /// <param name="id">ID da categoria a ser excluída</param>
    /// <returns>Categoria excluída</returns>
    public async Task<Category> Delete(int id)
    {
        var category = await GetById(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
    #endregion

}
