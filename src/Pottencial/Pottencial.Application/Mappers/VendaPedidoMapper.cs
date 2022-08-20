using Pottencial.Application.Dtos;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Enums;

namespace Pottencial.Application.Mappers;

public static class VendaPedidoMapper
{
    public static Venda ToDomain(VendaPedidoViewModel viewModel)
    {
        return new(EnumStatusVenda.AguardandoPagamento)
        {
            Data = DateTime.Now,
            Vendedor = new(viewModel.VendedorCPF)
            {
                Nome = viewModel.VendedorNome,
                Telefone = viewModel.VendedorTelefone ?? "",
                Email = viewModel.VendedorEmail ?? ""
            },
            PedidoItem = new(viewModel.ProdutoId, viewModel.ProdutoPreco, viewModel.ProdutoQuantidade, Convert.ToDecimal(viewModel.Frete)),
            UltimaAlteracao = DateTime.Now
        };
    }
}
