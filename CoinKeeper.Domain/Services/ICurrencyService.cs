using Domain.Currencies;

namespace Domain.Services;

public interface ICurrencyService
{
    public Task<CurrencyConverterApiResponse> GetBasicCurrenciesInfo();
}