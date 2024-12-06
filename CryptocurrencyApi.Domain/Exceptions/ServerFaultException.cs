using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.Exceptions
{
  public class ServerFaultException:CustomException
  {
    public Exception? InnerException { get; set; }
    public ServerFaultException(string message="Ocurrión un error inesperado, inténtelo más tarde.", int code=0, Exception? innerException=null) : base(message, code)
    {
      Message = message;
      Code = code;
      InnerException = innerException;
    }
  }
}
