using System.Collections.Generic;

namespace Enviroment.Domain
{
    public interface IEndereco
    {
        string Logradouro {get; set;}
        string Numero {get; set;}
        string Cep {get; set;}
        List<string> Referencias {get; set;}
    }
}