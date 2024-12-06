using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Application.Interfaces.Services.Cryptocurrencies;
using CryptocurrencyApi.Domain.Entities.Cryptocurrencies;
using CryptocurrencyApi.Domain.Exceptions;
using CryptocurrencyApi.Domain.Models.DTO.Cryptocurrencies;
using CryptocurrencyApi.Domain.Models.Requests.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Data;
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
    public async Task<CryptocurrencyDTO> CreateCryptocurrency(CreateCryptocurrencyRequest cryptocurrencyRequest)
    {
      var cryptocurrencyCode = await _cryptocurrencyRepository.GetCryptocurrencyByCode(cryptocurrencyRequest.Code);
      if (cryptocurrencyCode != null && cryptocurrencyCode.Status) {
        throw new ClientFaultException("Ya existe una criptomoneda con este código.");
      }

      var cryptocurrencyName = await _cryptocurrencyRepository.GetCryptocurrencyByName(cryptocurrencyRequest.Name);
      if (cryptocurrencyName != null && cryptocurrencyName.Status) {
        throw new ClientFaultException("Ya existe una criptomoneda con este nombre.");
      }

      var cryptocurrency = await _cryptocurrencyRepository.CreateCryptocurrency(new Cryptocurrency {
        Code = cryptocurrencyRequest.Code,
        Symbol=cryptocurrencyRequest.Symbol,
        Name=cryptocurrencyRequest.Name,
        Description=cryptocurrencyRequest.Description,
        Status = true
      });

      return new CryptocurrencyDTO {
        Id=cryptocurrency.Id,
        Code=cryptocurrency.Code,
        Symbol=cryptocurrency.Symbol,
        Name=cryptocurrency.Name,
        Description = cryptocurrency.Description,
        Status = cryptocurrency.Status
      };
    }

    public async Task DeleteCryptocurrency(int id)
    {
      var cryptocurrencyId = await _cryptocurrencyRepository.GetCryptocurrencyById(id);
      if (cryptocurrencyId == null) {
        throw new ClientFaultException("La moneda que intenta eliminar no existe.");
      }

      await _cryptocurrencyRepository.DeleteCryptocurrency(id);
    }

    public async Task<CryptocurrencyDTO> GetCryptocurrencyById(int id)
    {
      var currency = await _cryptocurrencyRepository.GetCryptocurrencyById(id);
      return new CryptocurrencyDTO {
        Id = currency.Id,
        Code = currency.Code,
        Symbol = currency.Symbol,
        Name = currency.Name,
        Description = currency.Description,
        Status = currency.Status
      };
    }

    public async Task<List<CryptocurrencyDTO>> ListCryptocurrencies(int limit, int offset, string filter)
    {
      return (await _cryptocurrencyRepository.ListCryptocurrencies(limit, offset, filter)).Select(currency => new CryptocurrencyDTO
      {
        Id = currency.Id,
        Code = currency.Code,
        Symbol = currency.Symbol,
        Name = currency.Name,
        Description = currency.Description,
        Status = currency.Status
      }).ToList();
    }

    public async Task<CryptocurrencyDTO> UpdateCryptocurrency(UpdateCryptocurrencyRequest cryptocurrencyRequest)
    {
      var cryptocurrencyId = await _cryptocurrencyRepository.GetCryptocurrencyById(cryptocurrencyRequest.Id);
      if (cryptocurrencyId == null) {
        throw new ClientFaultException("La criptomoneda que intenta actualizar no existe.");
      }

      var cryptocurrencyName = await _cryptocurrencyRepository.GetCryptocurrencyByName(cryptocurrencyRequest.Name);
      if (cryptocurrencyName != null && cryptocurrencyName.Id!=cryptocurrencyName.Id && cryptocurrencyName.Status) {
        throw new ClientFaultException("Ya existe una criptomoneda con este nombre.");
      }

      var cryptocurrency = await _cryptocurrencyRepository.UpdateCryptocurrency(new Cryptocurrency {
        Id = cryptocurrencyRequest.Id,
        Symbol = cryptocurrencyRequest.Symbol,
        Name = cryptocurrencyRequest.Name,
        Description = cryptocurrencyRequest.Description,
        Status = true
      });

      return new CryptocurrencyDTO {
        Id = cryptocurrency.Id,
        Code = cryptocurrency.Code,
        Symbol = cryptocurrency.Symbol,
        Name = cryptocurrency.Name,
        Description = cryptocurrency.Description,
        Status = cryptocurrency.Status
      };
    }
  }
}
