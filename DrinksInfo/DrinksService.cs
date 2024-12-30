using DrinksInfo.Models;
using System.Net.Http.Headers;
using System.Text.Json;


namespace DrinksInfo;

class DrinksService
{
    private readonly HttpClient _httpClient;

    public DrinksService()
    {
        // Initialise HttpClient with base address for API
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
        };

        // Clear any existing Accept headers
        _httpClient.DefaultRequestHeaders.Accept.Clear();

        // Add Accept header to specify format of data (JSON)
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );

        // Add User-Agent header to identify app to API
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "DrinksInfo");
    }
    internal async Task<List<Category>> GetDrinksCategoriesAsync()
    {
        try
        {
            var requestUri = "list.php?c=list";

            // Get the stream of data from the API
            await using Stream stream =
                    await _httpClient.GetStreamAsync(requestUri);

            // Deserialise the stream to List<Category>
            var categories =
                await JsonSerializer.DeserializeAsync<Categories>(stream);

            return categories?.CategoriesList ?? new List<Category>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Category>();
        }
    }
}