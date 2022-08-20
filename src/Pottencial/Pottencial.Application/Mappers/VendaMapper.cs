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
            PedidoItem = new(viewModel.ProdutoId, viewModel.ProdutoPreco, viewModel.ProdutoQuantidade, Convert.ToDecimal(viewModel.Frete)),
        };
    }

    public static VendaViewModel ToViewModel(Venda domain)
    {
        return new()
        {
            Id = domain.Id,
            Data = Convert.ToDateTime(domain.Data),
            UltimaAlteracao = domain.UltimaAlteracao,
            Frete = domain.PedidoItem.Frete,
            Produto = domain.PedidoItem.Item.Produto,
            ProdutoPreco = domain.PedidoItem.Item.Valor,
            ProdutoId = (int)domain.PedidoItem.Item.EnumTipoProduto,
            ProdutoQuantidade = domain.PedidoItem.Quantidade,
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
