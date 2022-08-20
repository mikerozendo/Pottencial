using Pottencial.Domain.Entities;
using Pottencial.Domain.Enums;
using Pottencial.Domain.Exceptions;
using Pottencial.Domain.Interfaces.Repositories;
using Pottencial.Domain.Interfaces.Services;
using Pottencial.Domain.ValueObjects;

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

    public Venda AlterarStatusVenda(int idVenda, int statusAlteracao)
    {
        var venda = _vendaRepository.Get(idVenda).FirstOrDefault();

        try
        {
            if (venda is not null)
            {
                if (Enum.IsDefined((EnumStatusVenda)statusAlteracao))
                {
                    venda.AlterarStatusVendaBuilder((EnumStatusVenda)statusAlteracao);
                    _vendaRepository.RemovePorId(venda.Id);
                    _vendaRepository.Post(venda);
                    return venda;
                }

                throw new StatusInvalidoException(VendaStatusQValida.NaoIdentificado);
            }

            throw new Exception("Venda não encontrada na base");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<Venda> Get()
    {
        return _vendaRepository.Get();
    }

    public Venda GetById(int id)
    {
        return _vendaRepository.Get(id).FirstOrDefault();
    }

    public Venda Post(Venda venda)
    {
        var vendedorExistente = _vendedorService.ObterPorDocumento(venda.Vendedor);

        if (vendedorExistente is null)
            _vendedorService.Post(venda.Vendedor);

        return _vendaRepository.Post(venda);
    }
}
