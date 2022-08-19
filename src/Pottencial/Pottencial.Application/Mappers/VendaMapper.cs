using Pottencial.Application.Dtos;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Enums;

namespace Pottencial.Application.Mappers;

public static class VendaMapper
{
    public static Venda ToDomain(VendaViewModel viewModel)
    {
        return new((EnumStatusVenda)viewModel.StatusId)
        {
            Data = Convert.ToDateTime(viewModel.Data),
            Vendedor = new(viewModel.VendedorCPF)
            {
                Nome = viewModel.VendedorNome,
                Telefone = viewModel.VendedorTelefone ?? "",
                Email = viewModel.VendedorEmail ?? ""
            },
            PedidoItem = new()
            {
                Frete = viewModel.Frete ?? 0,
                Item = new()
                {
                    Produto = viewModel.Produto,
                    Valor = viewModel.ProdutoPreco
                },
                Quantidade = viewModel.ProdutoQuantiade,
            }
        };
    }
}
