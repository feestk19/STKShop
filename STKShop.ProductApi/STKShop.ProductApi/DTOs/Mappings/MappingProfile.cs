#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe MappingProfile
 */

/*------------------------------------------
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Ajuste para mapear nome da categoria
 -----------------------------------------*/
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
        CreateMap<ProductDTO, Product>();
        CreateMap<Product, ProductDTO>()
         .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}
