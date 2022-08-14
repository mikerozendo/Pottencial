using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repositories;

namespace Pottencial.Infraestructure.Data.Repositories;

public class PessoaRepository : IPessoaRepository
{
    public IEnumerable<Pessoa> Get()
    {
        return new List<Pessoa>
        {
            new(){ Id = 1, Nome =  "Michae", Sobrenome ="Rozendo"},
            new(){ Id = 1, Nome =  "Alice", Sobrenome = "Waters"},
            new(){ Id = 1, Nome =  "Joana", Sobrenome = "Joan"},
            new(){ Id = 1, Nome =  "Jonas", Sobrenome = "Traveller"},
            new(){ Id = 1, Nome =  "Sandra", Sobrenome = "Bullock"}
        };
    }
}
