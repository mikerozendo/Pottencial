using Pottencial.Application.Interfaces;
using Pottencial.Application.Mappers;
using Pottencial.Domain.Interfaces.Services;
using Pottencial.Application.Utils;
using Pottencial.Application.Dtos.Reponses;
using Pottencial.Application.Dtos.Adapters;

namespace Pottencial.Application.Services;

public class VendaAppService : IVendaAppService
{
    private readonly IVendaService _vendaService;
    public VendaAppService(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    public VendaViewModel AlterarStatusVenda(int idVenda, int statusAlteracao)
    {
        try
        {
            return VendaMapper.ToViewModel(_vendaService.AlterarStatusVenda(idVenda, statusAlteracao));
        }
        catch (Exception)
        {
            throw;
        }
    }

    public PaginacaoVendaViewModel Get(int pagina = 1)
    {
        var list = _vendaService.Get().Select(VendaMapper.ToViewModel);

        var helper = new Paginador<VendaViewModel>();
        int quantidadPaginas = helper.ObterQuantidadePaginas(list);
        var vendas = new PaginacaoVendaViewModel()
        {
            QuantidadePaginas = quantidadPaginas,
            Pagina = quantidadPaginas < pagina ? 0 : 1,
            Vendas = list
                    .Skip((pagina == 1 || quantidadPaginas < pagina ) ? 0 : (pagina - 1) * helper.QuantidadeMaximaItens)
                    .Take(helper.QuantidadeMaximaItens)
                    .ToList()
        };

        return vendas;
    }

    public VendaViewModel? GetByid(int id)
    {
        var venda = _vendaService.Get(id).FirstOrDefault();

        if (venda is null) return null;

        return VendaMapper.ToViewModel(venda);
    }

    public VendaViewModel Post(VendaPedidoViewModel viewModel)
    {
        return VendaMapper.ToViewModel(_vendaService.Post(VendaPedidoMapper.ToDomain(viewModel)));
    }
}
