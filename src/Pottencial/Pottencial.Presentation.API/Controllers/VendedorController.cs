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

    /// <summary>
    ///    Retorna base de dados paginada
    /// </summary>
    /// <param name="pagina">opcional</param>
    /// <param name="cpf">opcional</param>
    /// <param name="id">opcional</param>
    /// <returns>Retorna listagem paginada de dados da base, onde cada pagina contém no máximo 10 itens</returns>
    /// <returns>Vendedor pelo Id caso parametro seja utilizado</returns>
    /// <response code="201">Retorna paginação da base, se o perametro não for passado, o sistema retorna a primeira página, 
    ///     se a página requisitada for maior do que a quantidade contida no sitema; também é retornada a primeira página</response>
    /// <response code="204">Não possui nenhum registro na base</response>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Get([FromQuery] string? cpf = "", int? id = 0, int? pagina = 1)
    {
        var paginador = _vendedorAppService.Get(cpf, Convert.ToInt32(id), Convert.ToInt32(pagina));

        if (paginador.Vendedores.Any()) return Ok(paginador);

        return NoContent();
    }

    /// <summary>
    ///     Cria um vendedor na base de dados
    /// </summary>
    /// <param name="vendedor"></param>
    /// <returns>O Vendedor cadastrado</returns>
    /// <response code="201">Retorna o vendedor criado</response>
    /// <response code="400">Cpf inválido ou vendedor já esta cadastrado na base</response>
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
            var resource = _vendedorAppService.Post(vendedor);

            if(resource.GetType().Equals(typeof(VendedorErrorViewModel))) return BadRequest(resource);

            return Created(nameof(Post), resource);

        }
        catch (Exception ex)
        {
            return BadRequest(new ErrorViewModel(400, ex.Message));
        }
    }

    /// <summary>
    ///     Atualiza informações do vendedor na base de dados
    /// </summary>
    /// <param name="vendedor"></param>
    /// <returns>O Vendedor atualizado</returns>
    /// <response code="202">Retorna o vendedor com dados atualizados</response>
    /// <response code="400">Cpf inválido ou vendedor já esta cadastrado na base</response>
    /// <response code="401">Usuário não esta autenticado no sistema</response>
    [HttpPut]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Put([FromBody] VendedorViewModel vendedor)
    {
        try
        {
            var resource = _vendedorAppService.Put(vendedor);

            if(resource.GetType().Equals(typeof(VendedorPutSucessoViewModel))) return Accepted(nameof(Put), resource);

            //Error viewModel result;
            return NotFound(resource); 
        }
        catch (Exception ex)
        {
            return BadRequest(new ErrorViewModel(400, ex.Message));
        }
    }

    /// <summary>
    ///     Apaga registro da base pelo id do vendedor
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Vazio</returns>
    /// <response code="204"></response>
    /// <response code="401">Usuário não esta autenticado no sistema</response>
    /// <response code="404">Vendedor não cadastrado no sistema</response>
    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Delete([FromRoute] int id)
    {
        var vendedor = _vendedorAppService.Get(String.Empty, id, 1);

        if (vendedor.Vendedores.Any())
        {
            _vendedorAppService.Delete(id); 
            return NoContent();
        }

        return NotFound(new ErrorViewModel(404, "Você esta tentenado deletar um vendedor não cadastro no sistema"));
    }
}
