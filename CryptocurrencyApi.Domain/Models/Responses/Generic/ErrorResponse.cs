using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.DTO.Responses.Generic {
  public class ErrorResponse : BaseResponse{
    public Error ResponseError { get; set; }
    public ErrorResponse(int code, string message, Error error):base(code, message)
    {
      ResponseError = error;
    }
    public struct Error { public int Code; public string ErrorMessage; }
  }
  
}
