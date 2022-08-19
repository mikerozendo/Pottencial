using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;

namespace Pottencial.Presentation.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VendaController : AppBaseController
{
    private readonly IVendaAppService _vendaAppService;
    public VendaController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _vendaAppService = (IVendaAppService)GetService(typeof(IVendaAppService));
    }

    [HttpPost]
    public IActionResult Post([FromBody] VendaViewModel viewModel)
    {
        try
        {
            return Created(nameof(Post), _vendaAppService.Post(viewModel));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
