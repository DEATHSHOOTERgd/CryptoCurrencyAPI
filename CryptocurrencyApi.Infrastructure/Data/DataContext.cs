using CryptocurrencyApi.Domain.Entities.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Repositories.Coingecko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Infrastructure.Data
{
  public class DataContext {
    public List<Cryptocurrency> Cryptocurrencies { get; set; }
    public DataContext() {
      Cryptocurrencies = new List<Cryptocurrency>();
    }
  }
}
