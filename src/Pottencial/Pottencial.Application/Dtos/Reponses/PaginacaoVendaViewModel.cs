using Pottencial.Application.Dtos.Adapters;
using Pottencial.Application.Dtos.Base;

namespace Pottencial.Application.Dtos.Reponses;

public class PaginacaoVendaViewModel : BasePaginacaoViewModel
{
    public IEnumerable<VendaViewModel> Vendas { get; set; }
}
