using CoinKeeper.Services.Currency;
using Domain.Currencies;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CurrencyController : Controller
{
    private readonly ICurrencyService CurrencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        CurrencyService = currencyService;
    }
    
    [HttpGet]
    public async Task<CurrencyConverterApiResponse> GetBasicCurrencies()
    {
        return await CurrencyService.GetBasicCurrenciesInfo();
    } 
}