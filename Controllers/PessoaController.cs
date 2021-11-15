using Desafio.AMcom.Model;
using Desafio.AMcom.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.AMcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaService _pessoaService;


        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }


        [HttpGet("pessoas")]
        public Pessoa Index(string name, string email)
        {

           return _pessoaService.BuscarPessoa(name, email);
 
 
        }
    }
}
