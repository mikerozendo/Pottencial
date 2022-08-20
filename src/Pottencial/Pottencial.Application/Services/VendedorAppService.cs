using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Mappers;
using Pottencial.Domain.Interfaces.Services;

namespace Pottencial.Application.Services;

public class VendedorAppService : IVendedorAppService
{
    private readonly IVendedorService _vendedorService;
    public VendedorAppService(IVendedorService vendedorService)
    {
        _vendedorService = vendedorService;
    }

    public IEnumerable<VendedorViewModel> Get()
    {
        var vendedores = _vendedorService.Get();

        if (vendedores is null) return new List<VendedorViewModel>();

        return vendedores.Select(VendedorMapper.ToViewModel).ToList();
    }

    public VendedorViewModel Post(VendedorViewModel vendedor)
    {
        return VendedorMapper.ToViewModel(_vendedorService.Post(VendedorMapper.ToDomain(vendedor)));
    }

    public VendedorViewModel Put(VendedorViewModel vendedor)
    {
        return VendedorMapper.ToViewModel(_vendedorService.Put(VendedorMapper.ToDomain(vendedor)));
    }

    public void Delete(VendedorViewModel vendedor)
    {
        _vendedorService.Delete(VendedorMapper.ToDomain(vendedor));
    }
}
