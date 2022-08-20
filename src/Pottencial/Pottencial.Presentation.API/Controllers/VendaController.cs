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

    /// <summary>
    ///    Retorna base de dados paginada
    /// </summary>
    /// <param name="pagina">opcional</param>
    /// <returns>Retorna listagem paginada de dados da base, onde cada pagina contém no máximo 10 itens</returns>
    /// <response code="201">Retorna paginação da base, se o perametro não for passado, o sistema retorna a primeira página, 
    ///     se a página requisitada for maior do que a quantidade contida no sitema; também é retornada a primeira página</response>
    /// <response code="204">Não possui nenhum registro na base</response>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get([FromQuery] int? pagina = 1)
    {
        var list = _vendaAppService.Get(Convert.ToInt32(pagina));

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


    /// <summary>
    ///     Registra uma venda na base
    /// </summary>
    /// <param name="vendaPedidoViewModel"></param>
    /// <returns>Retorna venda registrada e informações do vendedor</returns>
    /// <response code="201">Retorna venda registrada</response>
    /// <response code="400">Indica possível falha no cadastro dovendedor</response>
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] VendaPedidoViewModel vendaPedidoViewModel)
    {
        try
        {
            return Created(nameof(Post), _vendaAppService.Post(vendaPedidoViewModel));
        }
        catch (Exception ex)
        {
            return BadRequest(new ErrorViewModel(400, ex.Message));
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
            return BadRequest(new ErrorViewModel(400, ex.Message));
        }
    }
}
