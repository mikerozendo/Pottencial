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

    public IEnumerable<Vendedor> Get(int id = 0)
    {
        return _vendedorRepository.Get(id);
    }

    public Vendedor Post(Vendedor vendedor)
    {
        vendedor.Id = _vendedorRepository.ObterQuantiadeVendedores() + 1;

        return _vendedorRepository.Post(vendedor);
    }

    public Vendedor Put(Vendedor vendedor)
    {
        var existente = _vendedorRepository.ObterPorDocumento(vendedor);

        if (existente is not null)
        {
            vendedor.Id = existente.Id;

            _vendedorRepository.Remove(existente);
        }

        return Post(vendedor);
    }

    public void Delete(int idVendedor)
    {
        var vendedor = _vendedorRepository.Get(idVendedor).FirstOrDefault();

        if (vendedor is not null)
            _vendedorRepository.Remove(vendedor);
    }

    public Vendedor? ObterPorDocumento(Vendedor vendedor)
    {
        return _vendedorRepository.ObterPorDocumento(vendedor);
    }
}
