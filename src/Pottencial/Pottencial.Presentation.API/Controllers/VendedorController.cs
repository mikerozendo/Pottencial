using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;

namespace Pottencial.Presentation.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VendedorController : AppBaseController
{
    private readonly IVendedorAppService _vendedorAppService;
    public VendedorController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _vendedorAppService = (IVendedorAppService)GetService(typeof(IVendedorAppService));
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = _vendedorAppService.Get().ToList();

        if (list.Count == 0) 
            return NoContent();

        return Ok(list);
    }

    [HttpPost]
    public IActionResult Post([FromBody] VendedorViewModel vendedor)
    {
        try
        {
            var created = _vendedorAppService.Post(vendedor);
            return Created(nameof(Post), created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] VendedorViewModel vendedor)
    {
        try
        {
            var created = _vendedorAppService.Put(vendedor);
            return Accepted(nameof(Post), created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] VendedorViewModel vendedor)
    {
        _vendedorAppService.Delete(vendedor); return NoContent();
    }
}
