using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.DTO.Responses.Generic {
  public class BaseResponse {
    public int Code { get; set; }
    public string Message { get; set; }

    public BaseResponse(int code, string message) {
      Code = code;
      Message = message;
    }
    
  }
}
