using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.Models.DTO.Cryptocurrencies {
  public class CryptocurrencyDTO {
    public string Id { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }

  }
}
