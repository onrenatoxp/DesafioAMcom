using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.AMcom.Services
{
   public interface IPaisesService
    {
        List<Pais> RetornaPaises();
        Pais RetornaPaisPorSigla(string sigla);
    }
}
