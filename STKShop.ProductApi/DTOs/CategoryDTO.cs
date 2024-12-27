#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe CategoryDTO
 */
#endregion


using STKShop.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace STKShop.ProductApi.DTOs;

/// <summary>
/// Classe DTO de Categoria
/// </summary>
public class CategoryDTO
{
    /// <summary>
    /// Category ID
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Category Name
    /// </summary>
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}
