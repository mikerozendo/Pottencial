using Pottencial.Domain.Entities;
using Pottencial.Domain.Services;

namespace Pottencial.Infraestructure.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        public IEnumerable<Pessoa> Get()
        {
            return new List<Pessoa>
            {
                new(){ Id = 1, Nome =  "Michae", Sobrenome ="Rozendo", Idade = 24},
                new(){ Id = 1, Nome =  "Alice", Sobrenome = "Waters", Idade = 24},
                new(){ Id = 1, Nome =  "Joana", Sobrenome = "Joan", Idade = 24},
                new(){ Id = 1, Nome =  "Jonas", Sobrenome = "Traveller",Idade = 24},
                new(){ Id = 1, Nome =  "Sandra", Sobrenome = "Bullock", Idade = 24}
            };
        }
    }
}
