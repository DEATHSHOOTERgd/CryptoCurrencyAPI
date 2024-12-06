using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.Exceptions
{
  public class ClientFaultException : CustomException
  {
    public int HttpCode { get; set; }
    public ClientFaultException(string message="Datos de la petición son incorrectos, por favor revisa la información enviada", int code=0, int httpCode = 400):base(message, code) {
      Message = message;
      Code = code;
      HttpCode = httpCode;
    }
  }
}
