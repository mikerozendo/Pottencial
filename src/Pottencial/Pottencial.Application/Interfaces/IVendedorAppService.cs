using Pottencial.Application.Dtos;

namespace Pottencial.Application.Interfaces;

public interface IVendedorAppService
{
    PaginacaoVendedoresViewModel Get(string cpf = "", int id = 0, int pagina = 1);
    VendedorViewModel? Post(VendedorViewModel vendedor);
    VendedorViewModel? Put(VendedorViewModel vendedor);
    void Delete(int idVendedor);
    VendedorErrorViewModel RetornaVendedorJaExistente(VendedorViewModel vendedor);
}
