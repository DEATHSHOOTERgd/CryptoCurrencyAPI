using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Domain.Entities.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Coingecko;
using CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Repositories.Coingecko;

namespace CryptocurrencyApi.Infrastructure.Seeders
{
  public static class CryptocurrenciesSeeder
  {
    public static async Task Seed(ICoinRepository coinRepository, ICryptocurrencyRepository cryptocurrencyRepository)
    {
      var coinList = await coinRepository.GetCoinList();
      foreach ( var coin in coinList ) {
        await cryptocurrencyRepository.CreateCryptocurrency(new Cryptocurrency
        {
          Id = coin.Id,
          Symbol = coin.Symbol,
          Name = coin.Name,
          Description = null,
          Status = true
        });
      }
    } 
  }
}
