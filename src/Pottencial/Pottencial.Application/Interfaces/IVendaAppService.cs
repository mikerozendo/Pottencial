using Pottencial.Application.Dtos;

namespace Pottencial.Application.Interfaces;

public interface IVendaAppService
{
    VendaViewModel Post(VendaViewModel viewModel);
    PaginacaoVendaViewModel Get(int pagina);
    VendaViewModel? GetByid(int id);
    VendaViewModel AlterarStatusVenda(int idVenda, int statusAlteracao);
}
