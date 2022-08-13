using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Mappers;
using Pottencial.Domain.Interfaces.Services;

namespace Pottencial.Application.Services
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;

        public PessoaAppService(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public IEnumerable<PessoaViewModel> Get()
        {
            return _pessoaService.Get().Select(PessoaMapper.ToViewModel).ToList();
        }
    }
}
