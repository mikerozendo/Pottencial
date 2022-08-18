using Pottencial.Application.Dtos;
using Pottencial.Domain.Entities;

namespace Pottencial.Application.Mappers;

public class VendedorMapper
{

    public Vendedor ToDomain(VendedorViewModel viewModel)
    {
        return new Vendedor(viewModel.Cpf)
        {
            Email = viewModel.Email,
            Nome = viewModel.Nome,
            Telefone = viewModel.Telefone
        };
    }
}
