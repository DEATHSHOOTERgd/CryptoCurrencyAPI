using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Domain.Entities.Cryptocurrencies;

namespace CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Cryptocurrencies
{
    public interface ICryptocurrencyRepository
    {
        public Task<List<Cryptocurrency>> ListCryptocurrencies(int limit, int offset);
        public Task<Cryptocurrency> GetCryptocurrencyById(string id);
        public Task<Cryptocurrency> CreateCryptocurrency(Cryptocurrency cryptocurrency);
        public Task<Cryptocurrency> UpdateCryptocurrency(Cryptocurrency cryptocurrency);
        public Task DeleteCryptocurrency(string id);
    }
}
