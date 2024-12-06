using CryptocurrencyApi.Application.Interfaces.Services.Cryptocurrencies;
using CryptocurrencyApi.Domain.DTO.Responses.Generic;
using CryptocurrencyApi.Domain.Models.DTO.Cryptocurrencies;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyApi.Api.Controllers.v1.Cryptocurrency {
  [ApiController]
  [Route("api/v1/cryptocurrency")]
  public class CryptocurrencyController : ControllerBase{
    private readonly ICryptocurrencyService _CryptocurrencyService;
    public CryptocurrencyController(ICryptocurrencyService CryptocurrencyApi) {
      _CryptocurrencyService = CryptocurrencyApi;
    }


    [HttpGet("list")]
    public async Task<ActionResult<SuccessResponse<List<CryptocurrencyDTO>>>> ListCryptocurrencies(int limit=20,int offset=0)
    {
      var response = await _CryptocurrencyService.ListCryptocurrencies(limit, offset);

      return Ok(new SuccessResponse<List<CryptocurrencyDTO>>(200, "Consulta exitosa", response));
    }
  }
}
