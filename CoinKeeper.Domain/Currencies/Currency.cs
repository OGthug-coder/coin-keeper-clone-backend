using System.Text.Json.Serialization;

namespace Domain.Currencies;

public class Currency
{
    [JsonPropertyName("currency_name")]
    public string CurrencyName { get; set; } = null!;

    [JsonPropertyName("rate")]
    public string Rate { get; set; } = null!;

    [JsonPropertyName("rate_for_amount")]
    public string RateForAmount { get; set; } = null!;
}