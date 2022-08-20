using Pottencial.Application.Dtos;

namespace Pottencial.Application.Interfaces;

public interface IVendedorAppService
{
    PaginacaoVendedoresViewModel Get(string cpf = "", int id = 0, int pagina = 1);
    object Post(VendedorViewModel vendedor);
    object Put(VendedorViewModel vendedor);
    void Delete(int idVendedor);
}
