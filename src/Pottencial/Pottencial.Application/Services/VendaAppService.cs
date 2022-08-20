using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Mappers;
using Pottencial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pottencial.Application.Utils;

namespace Pottencial.Application.Services;

public class VendaAppService : IVendaAppService
{
    private readonly IVendaService _vendaService;
    public VendaAppService(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    public PaginacaoVendaViewModel Get(int pagina)
    {
        var list = _vendaService.Get().Select(VendaMapper.ToViewModel);

        var helper = new Paginador<VendaViewModel>();

        var vendas = new PaginacaoVendaViewModel()
        {
            QuantidadePaginas = helper.ObterQuantidadePaginas(list),
            Pagina = pagina,
            Vendas = list
                    .Skip(pagina == 1 ? 0 : pagina * helper.QuantidadeMaximaItens)
                    .Take(helper.QuantidadeMaximaItens)
                    .ToList()
        };

        return vendas;
    }

    public VendaViewModel Post(VendaViewModel viewModel)
    {
        return VendaMapper.ToViewModel(_vendaService.Post(VendaMapper.ToDomain(viewModel)));
    }
}
