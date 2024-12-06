using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Application.Interfaces.Services.Cryptocurrencies;
using CryptocurrencyApi.Domain.Models.DTO.Cryptocurrencies;
using CryptocurrencyApi.Domain.Models.Requests.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Cryptocurrencies;

namespace CryptocurrencyApi.Application.Services.Cryptocurrencies
{
  public class CryptocurrencyService : ICryptocurrencyService
  {
    private readonly ICryptocurrencyRepository _cryptocurrencyRepository;
    public CryptocurrencyService(ICryptocurrencyRepository cryptocurrencyRepository)
    {
      _cryptocurrencyRepository = cryptocurrencyRepository;
    }
    public Task<CryptocurrencyDTO> CreateCryptocurrency(CryptocurrencyRequest cryptocurrencyRequest)
    {
      throw new NotImplementedException();
    }

    public Task DeleteCryptocurrency(string id)
    {
      throw new NotImplementedException();
    }

    public Task<CryptocurrencyDTO> GetCryptocurrencyById(string id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<CryptocurrencyDTO>> ListCryptocurrencies(int limit, int offset)
    {
      return (await _cryptocurrencyRepository.ListCryptocurrencies(limit, offset)).Select(currency => new CryptocurrencyDTO
      {
        Id = currency.Id,
        Symbol = currency.Symbol,
        Name = currency.Name,
        Description = currency.Description
      }).ToList();
    }

    public Task<CryptocurrencyDTO> UpdateCryptocurrency(CryptocurrencyRequest cryptocurrencyRequest)
    {
      throw new NotImplementedException();
    }
  }
}
