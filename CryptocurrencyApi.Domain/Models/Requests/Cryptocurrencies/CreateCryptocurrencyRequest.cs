using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.Models.Requests.Cryptocurrencies
{
    public class CreateCryptocurrencyRequest
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
