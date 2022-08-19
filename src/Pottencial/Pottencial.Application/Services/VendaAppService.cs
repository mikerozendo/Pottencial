using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Mappers;
using Pottencial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Application.Services;

public class VendaAppService : IVendaAppService
{
    private readonly IVendaService _vendaService;
    public VendaAppService(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    public VendaViewModel Post(VendaViewModel viewModel)
    {
        return VendaMapper.ToViewModel(_vendaService.Post(VendaMapper.ToDomain(viewModel)));
    }
}
