using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Services;

namespace Pottencial.Domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IEnumerable<Pessoa> Get()
        {
            return _pessoaRepository.Get();
        }
    }
}
