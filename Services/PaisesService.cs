using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Desafio.AMcom.Services
{
    public class PaisesService : IPaisesService
    {
        public List<Pais> RetornaPaises()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + @"\paises.json";
            string jsonResult = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<Pais>>(jsonResult);


        }

        public Pais RetornaPaisPorSigla(string sigla)
        {
            return this.RetornaPaises().Where(m => m.Sigla == sigla.ToUpper()).FirstOrDefault();
        }
    }
}
