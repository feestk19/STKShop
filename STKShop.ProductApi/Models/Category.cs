#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe Category
 */

#endregion

namespace STKShop.ProductApi.Models;

/// <summary>
/// Classe de Categoria
/// </summary>
public class Category
{
    /// <summary>
    /// Category ID
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Category Name
    /// </summary>
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}
