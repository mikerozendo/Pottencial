namespace Pottencial.Application.Dtos;

public class PaginacaoVendedoresViewModel : BasePaginacaoViewModel
{
    public IEnumerable<VendedorViewModel> Vendedores { get; set;}
}
