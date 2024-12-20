#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da interface IProductRepository
 */
#endregion

using Microsoft.EntityFrameworkCore;
using STKShop.ProductApi.Context;
using STKShop.ProductApi.Models;

namespace STKShop.ProductApi.Repositories;

/// <summary>
/// Classe ProductRepository
/// </summary>
public class ProductRepository : IProductRepository
{

    #region Declarações e DI
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Métodos
    /// <summary>
    /// Pega todos os Produtos
    /// </summary>
    /// <returns>Todas as Produtos cadastradas</returns>
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    /// <summary>
    /// Pega todas as Produtos com os produtos
    /// </summary>
    /// <returns>Todas as Produtos com os respectivos produtos</returns>
    public async Task<Product> GetById(int id)
    {
        return await _context.Products.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Cria um novo Produto
    /// </summary>
    /// <param name="category">Objeto do tipo Produto</param>
    /// <returns>Produto atualizada</returns>
    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    /// <summary>
    /// Atualiza um Produto
    /// </summary>
    /// <param name="category">Objeto do tipo Produto</param>
    /// <returns>Produto atualizado</returns>
    public async Task<Product> Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }

    /// <summary>
    /// Exclui um Produto
    /// </summary>
    /// <param name="id">ID do Produto a ser excluído</param>
    /// <returns>Produto excluído</returns>
    public async Task<Product> Delete(int id)
    {
        var product = await GetById(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }


    #endregion
}
