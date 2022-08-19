using Pottencial.Application.Dtos;

namespace Pottencial.Application.Interfaces;

public interface IVendedorAppService
{
    IEnumerable<VendedorViewModel> Get();
    VendedorViewModel Post(VendedorViewModel vendedor);
    VendedorViewModel Put(VendedorViewModel vendedor);
    void Delete(VendedorViewModel vendedor);
}
