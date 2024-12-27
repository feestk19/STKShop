#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe ProductDTO
 */

/*------------------------------------------
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Adicionada propriedade CategoryName
 -----------------------------------------*/
#endregion


using STKShop.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace STKShop.ProductApi.DTOs;

/// <summary>
/// Classe DTO de Produto
/// </summary>
public class ProductDTO
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    /// <summary>
    /// Product Price
    /// </summary>
    [Required(ErrorMessage = "The Price is Required")]
    public decimal Price { get; set; }

    /// <summary>
    /// Product description
    /// </summary>
    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Description { get; set; }

    /// <summary>
    /// Product Stock
    /// </summary>
    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1, 9999)]
    public long Stock { get; set; }

    /// <summary>
    /// Product Image URL
    /// </summary>
    public string? ImageURL { get; set; }
    public string? CategoryName { get; set; }

    public Category? Category { get; set; }

    public int CategoryId { get; set; }
}
