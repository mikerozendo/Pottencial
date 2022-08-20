using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Services;

public interface IVendedorService : IBaseService<Vendedor>
{
    Vendedor? ObterPorDocumento(Vendedor vendedor);
    void Delete(int idVendedor);
}
