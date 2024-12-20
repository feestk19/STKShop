#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe MappingProfile
 */
#endregion

using AutoMapper;
using STKShop.ProductApi.Models;

namespace STKShop.ProductApi.DTOs.Mappings;

/// <summary>
/// Classe de perfil de mapeameto dos DTOs
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
