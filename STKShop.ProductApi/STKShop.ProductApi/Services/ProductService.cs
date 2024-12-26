#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 25/12/2024
 MANUTENÇÃO: Implementação inicial da interface ICategoryService
 */

#endregion

using AutoMapper;
using STKShop.ProductApi.DTOs;
using STKShop.ProductApi.Models;
using STKShop.ProductApi.Repositories;

namespace STKShop.ProductApi.Services;

/// <summary>
/// Classe ProductService
/// </summary>
public class ProductService : IProductService
{
    #region DI e Declarações
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    #endregion

    #region Métodos
    /// <summary>
    /// Resgata todos os produtos
    /// </summary>
    /// <returns>Lista de todas os produtos</returns>
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    /// <summary>
    /// Resgata o produto pelo ID
    /// </summary>
    /// <param name="id">ID da produto</param>
    /// <returns>produto com o respectivo ID</returns>
    public async Task<ProductDTO> GetproductById(int id)
    {
        var productEntity = await _productRepository.GetById(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    /// <summary>
    /// Adiciona um novo produto
    /// </summary>
    /// <param name="productDTO">Objeto do tipo productDTO</param>
    /// <returns>produto criado</returns>
    public async Task Addproduct(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Create(productEntity);
        productDTO.Id = productEntity.Id;
    }

    /// <summary>
    /// Atualiza um produto
    /// </summary>
    /// <param name="productDTO">Objeto do tipo productDTO</param>
    /// <returns>Produto atualizado</returns>
    public async Task Updateproduct(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Update(productEntity);
    }

    /// <summary>
    /// Exclui um produto
    /// </summary>
    /// <param name="id">ID do produto</param>
    /// <returns>Produto excluído</returns>
    public async Task Removeproduct(int id)
    {
        var productEntity = _productRepository.GetById(id).Result;
        await _productRepository.Delete(productEntity.Id);
    }

    #endregion
}
