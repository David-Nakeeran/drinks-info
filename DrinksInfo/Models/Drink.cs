using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

internal class Drink
{
    [JsonPropertyName("strDrink")]
    public string? Name { get; set; }
}