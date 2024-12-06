using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Domain.Entities.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Data;
using CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Cryptocurrencies;

namespace CryptocurrencyApi.Infrastructure.Repositories.Cryptocurrencies
{
  public class CryptocurrencyRepository : ICryptocurrencyRepository
  {
    private readonly DataContext _dataContext;
    public CryptocurrencyRepository(DataContext dataContext) {
      _dataContext = dataContext;
    }
    public async Task<Cryptocurrency> CreateCryptocurrency(Cryptocurrency cryptocurrency)
    {
      _dataContext.Cryptocurrencies.Add(cryptocurrency);
      return cryptocurrency;
    }

    public Task DeleteCryptocurrency(string id)
    {
      throw new NotImplementedException();
    }

    public Task<Cryptocurrency> GetCryptocurrencyById(string id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Cryptocurrency>> ListCryptocurrencies(int limit, int offset)
    {
      return _dataContext.Cryptocurrencies.Where(currency => currency.Status).Skip(offset*limit).Take(limit).ToList();
    }

    public Task<Cryptocurrency> UpdateCryptocurrency(Cryptocurrency cryptocurrencyRequest)
    {
      throw new NotImplementedException();
    }
  }
}
