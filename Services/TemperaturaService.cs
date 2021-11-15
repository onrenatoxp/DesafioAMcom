using Microsoft.Extensions.Caching.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Desafio.AMcom.Services
{
    public class TemperaturaService : ITemperaturaService
    {

        private IMemoryCache _cache;
        private const string KEY = "temperaturas";

        public TemperaturaService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public Temperatura GetConversaoFahrenheit(double temperatura)
        {
            Temperatura dados = new Temperatura();

           if(!_cache.TryGetValue(KEY, out dados))
            {

                var valorFahrenheit = temperatura;
                var valorCelsius = (temperatura - 32.0) * (0.5555555555555556);
                var valovrKelvin = valorCelsius + 273.15;

                dados = new Temperatura
                {

                    ValorFahrenheit = valorFahrenheit,
                    ValorCelsius = valorCelsius,
                    ValorKelvin = valovrKelvin
                };

                this.SalvarEmCache(dados);

            }

            return dados;

        }
 
        private void SalvarEmCache(Temperatura temperaturas)
        { 
            _cache.Set<Temperatura>(KEY, temperaturas);

        }

     }
    
}
