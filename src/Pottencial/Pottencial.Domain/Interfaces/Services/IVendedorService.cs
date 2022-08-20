using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Services;

public interface IVendedorService
{
    IEnumerable<Vendedor> Get();
    Vendedor Post(Vendedor vendedor);
    Vendedor Put(Vendedor vendedor);
    Vendedor? ObterPorDocumento(Vendedor vendedor);
    void Delete(Vendedor vendedor);
}
