using Desafio.AMcom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.AMcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : Controller
    {
        private ILogger<PaisesController> _logger;
        private readonly IPaisesService _paisesService;

        public PaisesController(ILogger<PaisesController> logger, IPaisesService paisesService)
        {

            _logger = logger;
            _paisesService = paisesService;
        }

        [HttpGet("paises")]
        public List<Pais> RetornaPaises()
        {
            List<Pais> paises = _paisesService.RetornaPaises();
            _logger.LogInformation($"Resultado por sigla concluído: {paises}");

            return paises;
        }

        [HttpGet("pais-por-sigla")]
        public Pais RetornaPaisPorSigla(string sigla)
        {
            Pais pais = _paisesService.RetornaPaisPorSigla(sigla);

            _logger.LogInformation($"Resultado por sigla concluído: {pais}");

            return pais;
        }

    }
}
