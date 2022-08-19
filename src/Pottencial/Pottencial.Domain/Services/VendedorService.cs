using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repositories;
using Pottencial.Domain.Interfaces.Services;

namespace Pottencial.Domain.Services;

public class VendedorService : IVendedorService
{
    private readonly IVendedorRepository _vendedorRepository;
    public VendedorService(IVendedorRepository vendedorRepository)
    {
        _vendedorRepository = vendedorRepository;
    }

    public IEnumerable<Vendedor> Get()
    {
        return _vendedorRepository.Get();
    }

    public Vendedor Post(Vendedor vendedor)
    {
        vendedor.Id = _vendedorRepository.ObterQuantiadeVendedores() + 1;

        return _vendedorRepository.Post(vendedor);
    }

    public Vendedor Put(Vendedor vendedor)
    {
        _vendedorRepository.Remove(vendedor);

        return _vendedorRepository.Post(vendedor);
    }

    public void Delete(Vendedor vendedor)
    {
        _vendedorRepository.Remove(vendedor);
    }
}
