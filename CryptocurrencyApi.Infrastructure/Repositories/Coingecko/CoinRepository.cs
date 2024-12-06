using CryptocurrencyApi.Domain.Models.DTO.Coingecko;
using CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Coingecko;
using CryptocurrencyApi.Infrastructure.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Infrastructure.Repositories.Coingecko {
  public class CoinRepository : ICoinRepository {
    private readonly HttpUtils _httpUtils;
    private readonly string _coinserviceUrl;

    public CoinRepository(HttpUtils httpUtils, IConfiguration configuration) {
      _httpUtils = httpUtils;
      _coinserviceUrl = configuration["ApiUrls:Coingecko"]!;
    }
    public async Task<List<CoinDTO>> GetCoinList() {
      return await _httpUtils.sendRequest<List<CoinDTO>>(HttpMethod.Get, string.Format("{0}/api/v3/coins/list", _coinserviceUrl));
    }
  }
}
