using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Mappers;
using Pottencial.Application.Utils;
using Pottencial.Domain.Interfaces.Services;

namespace Pottencial.Application.Services;

public class VendedorAppService : IVendedorAppService
{
    private readonly IVendedorService _vendedorService;
    public VendedorAppService(IVendedorService vendedorService)
    {
        _vendedorService = vendedorService;
    }

    public PaginacaoVendedoresViewModel Get(string cpf = "", int id = 0, int pagina = 1)
    {
        var list = _vendedorService.Get(id).Select(VendedorMapper.ToViewModel);

        if (list is null) return new();

        var helper = new Paginador<VendedorViewModel>();
        int quantidadPaginas = helper.ObterQuantidadePaginas(list);

        var vendedores = new PaginacaoVendedoresViewModel()
        {
            QuantidadePaginas = helper.ObterQuantidadePaginas(list),
            Pagina = quantidadPaginas < pagina ? 0 : 1,
            Vendedores = list
                    .Where(x => String.IsNullOrEmpty(cpf) || x.Cpf.Contains(cpf))
                    .Skip((pagina == 1 || quantidadPaginas < pagina) ? 0 : (pagina - 1) * helper.QuantidadeMaximaItens)
                    .Take(helper.QuantidadeMaximaItens)
                    .ToList()
        };

        return vendedores;
    }

    public VendedorViewModel? Post(VendedorViewModel vendedor)
    {
        var domainEntity = VendedorMapper.ToDomain(vendedor);

        if (_vendedorService.ObterPorDocumento(domainEntity) is not null) return null;

        return VendedorMapper.ToViewModel(_vendedorService.Post(domainEntity));
    }

    public VendedorViewModel? Put(VendedorViewModel vendedor)
    {
        var domainEntity = VendedorMapper.ToDomain(vendedor);
        if (_vendedorService.ObterPorDocumento(domainEntity) is not null) return null;

        return VendedorMapper.ToViewModel(_vendedorService.Put(domainEntity));
    }

    public VendedorErrorViewModel RetornaVendedorJaExistente(VendedorViewModel vendedor)
    {
        return new(400, "Você esta tentando cadastrar um vendedor já existente na base")
        {
            RecursoExistente = vendedor
        };
    }

    public void Delete(int idVendedor)
    {
        _vendedorService.Delete(idVendedor);
    }
}
