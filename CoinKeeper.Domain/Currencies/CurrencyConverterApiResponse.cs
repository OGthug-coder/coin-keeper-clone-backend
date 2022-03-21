using System.Text.Json.Serialization;

namespace Domain.Currencies;

public class CurrencyConverterApiResponse
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; }
    
    [JsonPropertyName("base_currency_code")]
    public string BaseCurrencyCode { get; set; }
    
    [JsonPropertyName("base_currency_name")]
    public string BaseCurrencyName { get; set; }
    
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    [JsonPropertyName("updated_date")]
    public DateTime UpdatedDate { get; set; }
    
    [JsonPropertyName("rates")]
    public Rates Rates { get; set; }
}