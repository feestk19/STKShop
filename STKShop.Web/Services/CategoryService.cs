#region Comentários de Manutenção

/*------------------------------------------
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Implementação inicial
 -----------------------------------------*/

#endregion

using STKShop.Web.Models;
using STKShop.Web.Services.Contracts;
using System.Text.Json;

namespace STKShop.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndPoint = "/api/categories/";

    public CategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;

        //Ignora letras maiusculas e minusculas na desserialização
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
    {
        IEnumerable<CategoryViewModel> categories;

        var client = RetornarHttpClient();

        var response = await client.GetAsync(apiEndPoint);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
        }
        else
        {
            return null;
        }

        return categories;
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
