using Pottencial.Application.Dtos;
using Pottencial.Domain.Entities;

namespace Pottencial.Application.Mappers
{
    public static class PessoaMapper
    {
        public static PessoaViewModel ToViewModel(Pessoa domain)
        {
            return new()
            {
                Idade = domain.Idade,
                NomeCompleto = String.Concat(domain.Nome, " ", domain.Sobrenome),
                Id = domain.Id
            };
        }
    }
}
