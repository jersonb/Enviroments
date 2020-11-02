using System.Collections.Generic;

namespace Enviroment.Domain
{
    public class Endereco : IEndereco
    {
        public string Logradouro {get; set;}

        public string Numero {get; set;}

        public string Cep {get; set;}

        public List<string> Referencias {get; set;}

    }
}