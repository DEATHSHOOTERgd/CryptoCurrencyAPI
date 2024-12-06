using CryptocurrencyApi.Domain.Models.DTO.Coingecko;
using CryptocurrencyApi.Domain.Models.Responses.Coingecko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Coingecko {
  public interface ICoinRepository {
    Task<List<CoinDTO>> GetCoinList();
  }
}
