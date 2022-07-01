using System.Text.Json.Serialization;

namespace Domain.Currencies;

public class Rates
{
    [JsonPropertyName("USD")]
    public Currency Usd { get; set; } = null!;

    [JsonPropertyName("EUR")]
    public Currency Eur { get; set; } = null!;
}