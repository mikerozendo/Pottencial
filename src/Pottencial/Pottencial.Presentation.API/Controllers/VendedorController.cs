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
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Get()
    {
        var list = _vendedorAppService.Get().ToList();

        if (list.Count == 0) 
            return NoContent();

        return Ok(list);
    }

    /// <summary>
    ///     Cria um vendedor na base de dados
    /// </summary>
    /// <param name="vendedor"></param>
    /// <returns>O Vendedor cadastrado</returns>
    /// <response code="201">Retorna o vendedor criado</response>
    /// <response code="400">Mensagem de erro específica, o CPF do vendedor deve ser Válido, o DV do mesmo é calculado.</response>
    /// <response code="401">Usuário não esta autenticado no sistema</response>
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Delete([FromBody] VendedorViewModel vendedor)
    {
        _vendedorAppService.Delete(vendedor); return NoContent();
    }
}
