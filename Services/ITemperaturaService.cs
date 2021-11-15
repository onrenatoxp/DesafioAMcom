using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.AMcom.Services
{
    public interface ITemperaturaService
    {
        Temperatura GetConversaoFahrenheit(double temperatura);
    }
}
