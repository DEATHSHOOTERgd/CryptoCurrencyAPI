using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Domain.Models.DTO.Cryptocurrencies;
using CryptocurrencyApi.Domain.Models.Requests.Cryptocurrencies;

namespace CryptocurrencyApi.Application.Interfaces.Services.Cryptocurrencies
{
  public interface ICryptocurrencyService
  {
        public Task<List<CryptocurrencyDTO>> ListCryptocurrencies(int limit, int offset, string filter);
        public Task<CryptocurrencyDTO> GetCryptocurrencyById(int id);
        public Task<CryptocurrencyDTO> CreateCryptocurrency(CreateCryptocurrencyRequest cryptocurrencyRequest);
        public Task<CryptocurrencyDTO> UpdateCryptocurrency(UpdateCryptocurrencyRequest cryptocurrencyRequest);
        public Task DeleteCryptocurrency(int id);
    }
}
