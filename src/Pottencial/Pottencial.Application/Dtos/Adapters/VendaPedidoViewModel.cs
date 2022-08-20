using Pottencial.Application.Dtos.Base;

namespace Pottencial.Application.Dtos.Adapters;

public class VendaPedidoViewModel : BaseViewModel
{
    public decimal ProdutoPreco { get; set; }
    public int ProdutoQuantidade { get; set; }
    public int ProdutoId { get; set; }
    public decimal? Frete { get; set; } = 0;
    public string VendedorNome { get; set; }
    public string VendedorCPF { get; set; }
    public string? VendedorEmail { get; set; } = "";
    public string? VendedorTelefone { get; set; } = "";
    public int? VendedorId { get; set; }
}
