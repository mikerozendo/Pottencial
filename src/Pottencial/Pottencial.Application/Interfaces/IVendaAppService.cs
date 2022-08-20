using Pottencial.Application.Dtos.Adapters;
using Pottencial.Application.Dtos.Reponses;

namespace Pottencial.Application.Interfaces;

public interface IVendaAppService
{
    VendaViewModel Post(VendaPedidoViewModel viewModel);
    PaginacaoVendaViewModel Get(int pagina = 1);
    VendaViewModel? GetByid(int id);
    VendaViewModel AlterarStatusVenda(int idVenda, int statusAlteracao);
}
