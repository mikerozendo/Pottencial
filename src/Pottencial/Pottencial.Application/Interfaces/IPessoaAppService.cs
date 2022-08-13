using Pottencial.Application.Dtos;

namespace Pottencial.Application.Interfaces
{
    public interface IPessoaAppService
    {
        IEnumerable<PessoaViewModel> Get();
    }
}
