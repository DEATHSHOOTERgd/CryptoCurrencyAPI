using CryptocurrencyApi.Application.Interfaces.Services.Cryptocurrencies;
using CryptocurrencyApi.Domain.DTO.Responses.Generic;
using CryptocurrencyApi.Domain.Models.DTO.Cryptocurrencies;
using CryptocurrencyApi.Domain.Models.Requests.Cryptocurrencies;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyApi.Api.Controllers.v1.Cryptocurrency {
  [ApiController]
  [Route("api/v1/cryptocurrency")]
  public class CryptocurrencyController : ControllerBase{
    private readonly ICryptocurrencyService _CryptocurrencyService;
    public CryptocurrencyController(ICryptocurrencyService CryptocurrencyApi) {
      _CryptocurrencyService = CryptocurrencyApi;
    }


    [HttpGet()]
    public async Task<ActionResult<SuccessResponse<List<CryptocurrencyDTO>>>> ListCryptocurrencies(int? limit=20,int? offset=0, string? filter="")
    {
      var response = await _CryptocurrencyService.ListCryptocurrencies(limit.Value, offset.Value, filter);

      return Ok(new SuccessResponse<List<CryptocurrencyDTO>>(200, "Consulta exitosa", response));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuccessResponse<CryptocurrencyDTO>>> GetCryptocurrencyById(int id) {
      var response = await _CryptocurrencyService.GetCryptocurrencyById(id);

      return Ok(new SuccessResponse<CryptocurrencyDTO>(200, "Consulta exitosa", response));
    }

    [HttpPost()]
    public async Task<ActionResult<SuccessResponse<CryptocurrencyDTO>>> CreateCryptocurrency(CreateCryptocurrencyRequest cryptocurrency) {
      var response = await _CryptocurrencyService.CreateCryptocurrency(cryptocurrency);

      return Ok(new SuccessResponse<CryptocurrencyDTO>(200, "Creación exitosa", response));
    }

    [HttpPut()]
    public async Task<ActionResult<SuccessResponse<CryptocurrencyDTO>>> UpdateCryptocurrency(UpdateCryptocurrencyRequest cryptocurrency) {
      var response = await _CryptocurrencyService.UpdateCryptocurrency(cryptocurrency);

      return Ok(new SuccessResponse<CryptocurrencyDTO>(200, "Actualización exitosa", response));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SuccessResponse<string>>> DeleteCryptocurrency(int id) {
      await _CryptocurrencyService.DeleteCryptocurrency(id);

      return Ok(new SuccessResponse<string>(200, "Eliminación exitosa", String.Format("Se eliminó la critomoneda coin id {0}", id)));
    }
  }
}
