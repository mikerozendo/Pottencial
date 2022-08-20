using Pottencial.Application.Dtos.Adapters;
using Pottencial.Application.Dtos.Base;

namespace Pottencial.Application.Dtos.Reponses;

public class PaginacaoVendedoresViewModel : BasePaginacaoViewModel
{
    public IEnumerable<VendedorViewModel> Vendedores { get; set; }
}
