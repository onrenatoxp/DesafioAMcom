using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.IO;
using Desafio.AMcom.Services;

namespace Desafio.AMcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturasController : ControllerBase
    {
        private ILogger<TemperaturasController> _logger;
        private readonly ITemperaturaService _temperaturaService;

        public TemperaturasController(ILogger<TemperaturasController> logger, ITemperaturaService temperaturaService)
        {
            _logger = logger;
            _temperaturaService = temperaturaService;
        }

        [HttpGet("Fahrenheit/{temperatura}")]
        public object GetConversaoFahrenheit(double temperatura)
        {
            Temperatura dados = new Temperatura();

         
            try
            {
               dados = _temperaturaService.GetConversaoFahrenheit(temperatura);

                _logger.LogInformation($"Recebida temperatura para conversão: {temperatura}");

              
            }
            catch (Exception err)
            {
                _logger.LogInformation("Ocorreu um problema ao converter");
            }

            _logger.LogInformation($"Resultado concluído: {dados.ValorCelsius}");
            _logger.LogInformation($"Resultado concluído: {dados.ValorFahrenheit}");
            _logger.LogInformation($"Resultado concluído: {dados.ValorKelvin}");

            return dados;
        }

        [HttpPost("txt")]
        public ActionResult SalvaTemperaturatxt(Temperatura temperatura)
        {
            StreamWriter file = new("temperatura.txt");
            
            file.WriteLine(temperatura.ValorKelvin);
            file.WriteLine(temperatura.ValorCelsius);
            file.WriteLine(temperatura.ValorFahrenheit);

            return Ok();
        }

     
    }
}
