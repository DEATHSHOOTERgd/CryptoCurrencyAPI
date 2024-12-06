using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyApi.Domain.Models.DTO.Coingecko;

namespace CryptocurrencyApi.Domain.Models.Responses.Coingecko
{
    public class CoinListResponse
    {
        public List<CoinDTO> CoinList { get; set; }
    }
}
