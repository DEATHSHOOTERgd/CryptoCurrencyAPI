using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Domain.Entities.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Data;

namespace CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Cryptocurrencies
{
    public interface ICryptocurrencyRepository
    {
    public Task<Cryptocurrency> CreateCryptocurrency(Cryptocurrency cryptocurrency);

    public Task DeleteCryptocurrency(int id);

    public Task<Cryptocurrency> GetCryptocurrencyById(int id);

    public Task<Cryptocurrency> GetCryptocurrencyByCode(string code);

    public Task<Cryptocurrency> GetCryptocurrencyByName(string name);

    public Task<List<Cryptocurrency>> ListCryptocurrencies(int limit, int offset, string filter);

    public Task<Cryptocurrency> UpdateCryptocurrency(Cryptocurrency cryptocurrencyRequest);
  }
}
