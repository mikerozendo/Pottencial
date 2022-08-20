using Pottencial.Application.Dtos;
using Pottencial.Domain.Entities;

namespace Pottencial.Application.Mappers;

public static class UsuarioMapper
{
    public static UsuarioLoginViewModel ToViewModel(Usuario domain)
    {
        return new()
        {
            Email = domain.Email,
        };
    }

    public static Usuario ToDomain(UsuarioLoginViewModel viewModel)
    {
        return new(viewModel.Email, viewModel.Senha);
    }
}
