#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe Product
 */

#endregion


namespace STKShop.ProductApi.Models;

/// <summary>
/// Classe de produto
/// </summary>
public class Product
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Product Price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Product description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Product Stock
    /// </summary>
    public long Stock { get; set; }

    /// <summary>
    /// Product Image URL
    /// </summary>
    public string? ImageURL { get; set; }

    public Category? Category { get; set; }

    public int CategoryId { get; set; }
}
