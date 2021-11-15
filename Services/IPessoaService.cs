using Desafio.AMcom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.AMcom.Services
{
    public interface IPessoaService
    {
        Pessoa BuscarPessoa(string nome, string email);
    }
}
