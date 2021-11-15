using Desafio.AMcom.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.AMcom.Services
{
    public class PessoaService: IPessoaService
    {

        //Usado o RestSharp para realizar chamada da api externa;


        private JObject GetJObject()
        {

            var restClient = new RestClient("https://reqres.in/api/users?page=2");
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            var response = restClient.Execute(request).Content;

            return JObject.Parse(response);

        }

        private Pessoa SetPessoa(IEnumerable<JToken> JTPessoas)
        {
            Pessoa pessoa = new Pessoa();


            if (JTPessoas != null)
            {

                foreach (KeyValuePair<string, JToken> sub_obj in (JObject)JTPessoas)
                {
                    pessoa = new Pessoa
                    {
                        id = sub_obj.Key == "id" ? int.Parse(sub_obj.Value.ToString()) : pessoa.id,
                        email = sub_obj.Key == "email" ? sub_obj.Value.ToString() : pessoa.email,
                        first_name = sub_obj.Key == "first_name" ? sub_obj.Value.ToString() : pessoa.first_name,
                        last_name = sub_obj.Key == "last_name" ? sub_obj.Value.ToString() : pessoa.last_name,
                        avatar = sub_obj.Key == "avatar" ? sub_obj.Value.ToString() : pessoa.avatar,

                    };

                }
            }

            return pessoa;


        }

        public Pessoa BuscarPessoa(string nome, string email)
        {

            Pessoa pessoa = new Pessoa();

            JObject json = this.GetJObject();
            IEnumerable<JToken> JTPessoas = new List<JToken>();

            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(email))
            {
                JTPessoas = json.SelectToken($"$.data[?(@.first_name == '{nome}'  && @.email == '{email}')]");

            }else if (!string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(email))
            {
                JTPessoas = json.SelectToken($"$.data[?(@.first_name == '{nome}')]");
            }
            else
            {
                JTPessoas = json.SelectToken($"$.data[?(@.email == '{email}')]");
            }

                return SetPessoa(JTPessoas);
 
           
        }
    }
}
