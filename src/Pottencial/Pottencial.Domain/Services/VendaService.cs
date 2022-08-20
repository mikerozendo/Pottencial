using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repositories;
using Pottencial.Domain.Interfaces.Services;

namespace Pottencial.Domain.Services;

public class VendaService : IVendaService
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IVendedorService _vendedorService;
    
    public VendaService(IVendaRepository vendaRepository, IVendedorService vendedorService)
    {
        _vendaRepository = vendaRepository;
        _vendedorService = vendedorService;
    }

    public IEnumerable<Venda> Get()
    {
        return _vendaRepository.Get();
    }

    public Venda Post(Venda venda)
    {
        var vendedorExistente = _vendedorService.ObterPorDocumento(venda.Vendedor);

        if (vendedorExistente is null)
            _vendedorService.Post(venda.Vendedor);

        return _vendaRepository.Post(venda);
    }
}
