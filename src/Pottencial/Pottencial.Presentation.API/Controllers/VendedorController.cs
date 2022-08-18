using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Interfaces;

namespace Pottencial.Presentation.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VendedorController : AppBaseController
{
    private readonly IVendedorAppService _vendedorAppService;
    public VendedorController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _vendedorAppService = (IVendedorAppService)GetService(typeof(IVendedorAppService));
    } 
}
