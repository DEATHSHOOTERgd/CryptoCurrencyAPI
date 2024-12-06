using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.Models.DTO.Coingecko
{
    public class CoinDTO
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
