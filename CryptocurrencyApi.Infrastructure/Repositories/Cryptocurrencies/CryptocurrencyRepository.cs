using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Domain.Entities.Cryptocurrencies;
using CryptocurrencyApi.Domain.Models.Requests.Cryptocurrencies;
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

    public async Task DeleteCryptocurrency(string id)
    {
      int index = _dataContext.Cryptocurrencies.FindIndex(currency => currency.Id == id);
      _dataContext.Cryptocurrencies[index].Status = false;
    }

    public async Task<Cryptocurrency> GetCryptocurrencyById(string id)
    {
      return _dataContext.Cryptocurrencies.FirstOrDefault(currency=>currency.Id == id);
    }

    public async Task<Cryptocurrency> GetCryptocurrencyByName(string name) {
      return _dataContext.Cryptocurrencies.FirstOrDefault(currency => currency.Name == name);
    }

    public async Task<List<Cryptocurrency>> ListCryptocurrencies(int limit, int offset, string filter)
    {
      return _dataContext.Cryptocurrencies.Where(currency => currency.Status && currency.Name.ToUpper().Contains(filter.ToUpper())).Skip(offset*limit).Take(limit).ToList();
    }

    public async Task<Cryptocurrency> UpdateCryptocurrency(Cryptocurrency cryptocurrencyRequest)
    {
      int index = _dataContext.Cryptocurrencies.FindIndex(currency => currency.Id == cryptocurrencyRequest.Id);
      if (index == 0) {
        return null;
      }
      _dataContext.Cryptocurrencies[index].Name = cryptocurrencyRequest.Name;
      _dataContext.Cryptocurrencies[index].Symbol = cryptocurrencyRequest.Symbol;
      _dataContext.Cryptocurrencies[index].Description = cryptocurrencyRequest.Description;
      _dataContext.Cryptocurrencies[index].Status = cryptocurrencyRequest.Status;

      return _dataContext.Cryptocurrencies[index];
    }
  }
}
