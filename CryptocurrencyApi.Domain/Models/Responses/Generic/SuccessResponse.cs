using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyApi.Domain.DTO.Responses.Generic {
  public class SuccessResponse<T> : BaseResponse{
    public T Data { get; set; }
    public SuccessResponse(int code, string message, T data):base(code, message) {
      Data = data;
    }
  }
}
