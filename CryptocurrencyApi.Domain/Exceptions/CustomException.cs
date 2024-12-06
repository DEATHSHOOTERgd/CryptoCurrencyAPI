using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.Exceptions
{
  public abstract class CustomException:Exception
  {
    public string Message {  get; set; }
    public int Code { get; set; }

    public CustomException(string message, int code):base(message) { 
      Message = message;
      Code = code;
    }

  }
}
