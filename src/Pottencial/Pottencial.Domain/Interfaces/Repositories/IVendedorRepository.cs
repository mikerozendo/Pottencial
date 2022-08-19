using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IVendedorRepository
{
    IEnumerable<Vendedor> Get(); 
    Vendedor Post(Vendedor vendedor);
    int ObterQuantiadeVendedores();
    void Remove(Vendedor vendedor);
}
