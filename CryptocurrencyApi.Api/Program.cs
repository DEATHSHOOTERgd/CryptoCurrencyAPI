using CryptocurrencyApi.Application.Interfaces.Services.Cryptocurrencies;
using CryptocurrencyApi.Application.Services.Cryptocurrencies;
using CryptocurrencyApi.Domain.DTO.Responses.Generic;
using CryptocurrencyApi.Domain.Exceptions;
using CryptocurrencyApi.Infrastructure.Data;
using CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Coingecko;
using CryptocurrencyApi.Infrastructure.Interfaces.Repositories.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Repositories.Coingecko;
using CryptocurrencyApi.Infrastructure.Repositories.Cryptocurrencies;
using CryptocurrencyApi.Infrastructure.Seeders;
using CryptocurrencyApi.Infrastructure.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<HttpUtils>();
builder.Services.AddSingleton<DataContext>();

builder.Services.AddScoped<ICoinRepository, CoinRepository>();
builder.Services.AddScoped<ICryptocurrencyRepository, CryptocurrencyRepository>();

builder.Services.AddScoped<ICryptocurrencyService, CryptocurrencyService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var cryptocurrencyRepository = services.GetRequiredService<ICryptocurrencyRepository>();
  var coinRepository = services.GetRequiredService<ICoinRepository>();

  await CryptocurrenciesSeeder.Seed(coinRepository, cryptocurrencyRepository);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(appError =>
{
  appError.Run(async context =>
  {
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var exception = exceptionHandlerPathFeature?.Error;

    string message = "Ocurrió un error inesperado";
    int code = 0;
    int statusCode = 500;

    if (exception != null) {
      if (exception is ClientFaultException) {
        var clientFault = exception as ClientFaultException;
        message = clientFault.Message;
        statusCode = clientFault.HttpCode;
        code = clientFault.Code;
      } else if (exception is ServerFaultException)
      {
        var serverFault = exception as ServerFaultException;
        message = serverFault.Message;
        statusCode = 500;
        code = serverFault.Code;
      }
    }

    context.Response.StatusCode = statusCode;
    context.Response.ContentType = "application/json";

    var problemDetails = new ErrorResponse(code, message, new ErrorResponse.Error { Code=code, ErrorMessage=message });

    await context.Response.WriteAsJsonAsync(problemDetails);
  });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
