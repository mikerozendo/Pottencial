using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Domain.Services;

public class VendaService : IVendaService
{
    private readonly IVendaService _vendaService;
    private readonly IVendedorService _vendedorService;
    
    public VendaService(IVendaService vendaService, IVendedorService vendedorService)
    {
        _vendaService = vendaService;
        _vendedorService = vendedorService;
    }

    public Venda Post(Venda venda)
    {
        var vendedorExistente = _vendedorService.ObterPorDocumento(venda.Vendedor);

        if (vendedorExistente is null)
            _vendedorService.Post(venda.Vendedor);

        return _vendaService.Post(venda);
    }
}
