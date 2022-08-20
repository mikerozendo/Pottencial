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


    public static VendaViewModel ToViewModel(Venda domain)
    {
        return new()
        {
            Data = Convert.ToDateTime(domain.Data),
            Frete = domain.PedidoItem.Frete,
            Produto = domain.PedidoItem.Item.Produto,
            ProdutoPreco = domain.PedidoItem.Item.Valor,
            ProdutoQuantiade = domain.PedidoItem.Quantidade,
            StatusId = (int)domain.EnumStatusVenda,
            ValorTotal = domain.PedidoItem.ValorTotal,
            VendedorNome = domain.Vendedor.Nome,
            VendedorCPF = domain.Vendedor.CPF.Cpf,
            VendedorEmail = domain.Vendedor.Email,
            VendedorTelefone = domain.Vendedor.Telefone,
            VendedorId = domain.Vendedor.Id,
            StatusDescricao = domain.EnumStatusVendaDescription,        
        };
    }
}
