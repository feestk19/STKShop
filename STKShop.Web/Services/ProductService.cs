#region Comentários de Manutenção

/*------------------------------------------
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Implementação inicial
 -----------------------------------------*/

#endregion

using STKShop.Web.Models;
using STKShop.Web.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace STKShop.Web.Services;

public class ProductService : IProductService
{

    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndPoint = "/api/products/";
    private ProductViewModel productVM;
    private IEnumerable<ProductViewModel> productsVM;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _clientFactory = httpClientFactory;

        //Ignora letras maiusculas e minusculas na desserialização
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    /// <summary>
    /// Resgata todos os produtos
    /// </summary>
    /// <returns>Todos os produtos</returns>
    public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
    {
        var client = RetornarHttpClient();

        using (var response = await client.GetAsync(apiEndPoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productsVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }

        }

        return productsVM;
    }

    /// <summary>
    /// Resgata o produto pelo Id
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>Produto conforme o Id</returns>
    public async Task<ProductViewModel> FindProductById(int id)
    {
        var client = RetornarHttpClient();

        using (var response = await client.GetAsync(apiEndPoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }

        }

        return productVM;
    }

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    /// <param name="productVM">Objeto contendo o produto</param>
    /// <returns>Produto enviado</returns>
    public async Task<ProductViewModel> CreateProduct(ProductViewModel productVM)
    {
        var client = RetornarHttpClient();

        StringContent content = new StringContent(JsonSerializer.Serialize(productVM), Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiEndPoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }

        }

        return productVM;
    }

    /// <summary>
    /// Altera um produto existente
    /// </summary>
    /// <param name="productVM">Objeto contendo o produto</param>
    /// <returns>Produto que foi alterado</returns>
    public async Task<ProductViewModel> UpdateProduct(ProductViewModel productVM)
    {
        var client = RetornarHttpClient();
        ProductViewModel productUpdated = new ProductViewModel();

        using (var response = await client.PutAsJsonAsync(apiEndPoint, productVM))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productUpdated = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }

        }

        return productUpdated;
    }

    /// <summary>
    /// Exclui um produto
    /// </summary>
    /// <param name="id">Id do produto</param>
    /// <returns>True ou False caso o produto seja excluido</returns>
    public async Task<bool> DeleteProductById(int id)
    {
        var client = RetornarHttpClient();

        using (var response = await client.DeleteAsync(apiEndPoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }

        return false;
    }

    #region Métodos de ajuda

    /// <summary>
    /// Retorna o HttpClient
    /// </summary>
    /// <param name="client">Instancia do HttpClientFactory</param>
    /// <returns></returns>
    private HttpClient RetornarHttpClient()
    {
        return _clientFactory.CreateClient("ProductApi");
    }
    #endregion
}
