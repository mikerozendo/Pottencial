namespace Pottencial.Application.Dtos;

public class PaginacaoVendaViewModel : BasePaginacaoViewModel
{
    public IEnumerable<VendaViewModel> Vendas { get; set; }
}
