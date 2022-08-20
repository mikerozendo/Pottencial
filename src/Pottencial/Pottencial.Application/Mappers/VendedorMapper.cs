using Pottencial.Application.Dtos.Adapters;
using Pottencial.Domain.Entities;

namespace Pottencial.Application.Mappers;

public static class VendedorMapper
{

    public static Vendedor ToDomain(VendedorViewModel viewModel)
    {
        return new Vendedor(viewModel.Cpf)
        {
            Email = viewModel.Email,
            Nome = viewModel.Nome,
            Telefone = viewModel.Telefone,
            Id = viewModel.Id
        };
    }

    public static VendedorViewModel ToViewModel(Vendedor domain)
    {
        return new VendedorViewModel
        {
            Email = domain.Email,
            Nome = domain.Nome,
            Telefone = domain.Telefone,
            Cpf = domain.CPF.Cpf,
            Id = domain.Id
        };
    }
}
