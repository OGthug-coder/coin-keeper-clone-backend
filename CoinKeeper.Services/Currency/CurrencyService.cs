using System.Net.Http.Headers;
using System.Text.Json;
using Domain.Currencies;
using Domain.Services;
using Microsoft.Extensions.Configuration;

namespace CoinKeeper.Services.Currency;

public class CurrencyService : ICurrencyService
{
    private const string BasicCurrenciesUrl = "currency/convert?format=json&from=RUB&to=USD,EUR&amount=";

    private readonly IConfiguration Configuration;
    private readonly IHttpClientFactory HttpClientFactory;
    public CurrencyService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        Configuration = configuration;
        HttpClientFactory = httpClientFactory;
    }
    
    public async Task<CurrencyConverterApiResponse> GetBasicCurrenciesInfo()
    {
        using (var client = HttpClientFactory.CreateClient("CurrencyService"))
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{client.BaseAddress}/{BasicCurrenciesUrl}")
            };

            await SetHeaders(request.Headers);
            
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CurrencyConverterApiResponse>(body);
            }
        }
    }

    private Task SetHeaders(HttpRequestHeaders headers)
    {
        headers.Add("x-rapidapi-host", "currency-converter5.p.rapidapi.com");
        headers.Add("x-rapidapi-key", Configuration["Currencies:x-rapidapi-key"]);
        return Task.CompletedTask;
    }
}