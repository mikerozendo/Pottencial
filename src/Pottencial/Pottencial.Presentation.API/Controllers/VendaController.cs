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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get([FromQuery] int pagina = 1)
    {
        var list = _vendaAppService.Get(pagina);

        if (list.Vendas.Any()) return Ok(list);

        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] int id)
    {
        var venda = _vendaAppService.GetByid(id);

        if (venda is null) return NotFound();

        return Ok(venda);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AlterarStatusVenda([FromRoute] int id, [FromQuery] int statusAlteracao)
    {
        try
        {
           return Accepted(nameof(AlterarStatusVenda), _vendaAppService.AlterarStatusVenda(id, statusAlteracao));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
