using Enviroment.Domain;

namespace Enviroments.Lib
{
    public class EnderecoService
    {
        private readonly IEndereco _e;

        public EnderecoService(IEndereco endereco)
        {
            _e = endereco;
        }

        public string Csv()
        {
            return $"{_e.Cep};{_e.Logradouro};{_e.Referencias[1]}";
        }
    }
}