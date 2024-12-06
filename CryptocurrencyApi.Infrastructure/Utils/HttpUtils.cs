using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CryptocurrencyApi.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace CryptocurrencyApi.Infrastructure.Utils {
  public class HttpUtils {
    private readonly ILogger<HttpUtils> _logger;

    public HttpUtils(ILogger<HttpUtils> logger) {
      _logger = logger;
    }
    public async Task<T> sendRequest<T>(HttpMethod method , string url, Object data = null, Dictionary<String, String> headers = null) {

      using (HttpClient httpClient = new HttpClient()) {
        try {
          
          var request = new HttpRequestMessage(method, url);
          
          if(headers != null) {
            foreach (var header in headers) {
              request.Headers.Add(header.Key, header.Value);
            }
          }

          if (data != null) {
            request.Content = new StringContent(JsonSerializer.Serialize(data));
          }

          var response = await httpClient.SendAsync(request);

          string responseBody = await response.Content.ReadAsStringAsync();

          var options = new JsonSerializerOptions
          {
            PropertyNameCaseInsensitive = true
          };

          return JsonSerializer.Deserialize<T>(responseBody, options);
        } catch (HttpRequestException e) {
          _logger.LogError(e.Message);
          throw new ServerFaultException("Error durante la petición HTTP.", (int)e.StatusCode, e);
        }
      }
    }
  }
}
