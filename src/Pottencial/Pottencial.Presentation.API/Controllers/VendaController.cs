using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Dtos.Adapters;
using Pottencial.Application.Dtos.Reponses;
using Pottencial.Application.Interfaces;

namespace Pottencial.Presentation.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
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
    /// <response code="401">Usuario não autenticado</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get([FromQuery] int? pagina = 1)
    {
        var list = _vendaAppService.Get(Convert.ToInt32(pagina));

        if (list.Vendas.Any()) return Ok(list);

        return NoContent();
    }

    /// <summary>
    ///     Retorna uma venda da base buscando pelo Id
    /// </summary>
    /// <param name="id">id do recurso</param>
    /// <returns>Retorna venda registrada e informações do vendedor</returns>
    /// <response code="200">Retorna venda registrada</response>
    /// <response code="404">Venda não encontrada na base</response>
    /// <response code="401">Usuario não autenticado</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult GetById([FromRoute] int id)
    {
        var venda = _vendaAppService.GetByid(id);

        if (venda is null) return NotFound(new ErrorViewModel(404,"Venda não encontrada na base"));

        return Ok(venda);
    }


    /// <summary>
    ///     Registra uma venda na base
    /// </summary>
    /// <remarks>
    /// 
    ///     Exemplo:
    ///
    ///     POST 
    ///     {
    ///       "produtoPreco": 447.32,
    ///       "produtoQuantidade": 6, -- Quantiade deve ser maior que 0
    ///       "produtoId": 2, -- Possíveis Ids de produto => Indefinido == 0, Calça jeans == 1, Bermuda jeans == 2, Camiseta == 3, Casaco corta-vento == 4, Jaqueta de couro == 5 
    ///       "frete": 60,
    ///       "vendedorNome": "", -- opcional caso vendedor já exista na base
    ///       "vendedorCPF": "cpf valido com ou sem caracteres", -- Basta informar o CPF do vendedor que a venda ira cadastrar um novo na base caso o mesmo não exista;
    ///       "vendedorEmail": "", -- opcional caso vendedor já exista na base
    ///       "vendedorTelefone": "", -- opcional caso vendedor já exista na base
    ///       "vendedorId": 1 -- não precisa informar, sistema irá atribuir Id de forma automatizada
    ///     }
    ///     
    /// </remarks>
    /// <param name="vendaPedidoViewModel">Sistema verifica se vendedor já existe na base com base no documento do mesmo, não precisa inserir demais informações</param>
    /// <returns>Retorna venda registrada e informações do vendedor</returns>
    /// <response code="201">Retorna venda registrada</response>
    /// <response code="400">Indica possível falha no cadastro do vendedor</response>
    /// <response code="401">Usuario não autenticado</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

    /// <summary>
    ///     Altera o status de uma venda
    /// </summary>
    /// <param name="id">id da venda à ser alterada</param>
    /// <param name="statusAlteracao">Novo status daquela venda
    ///     Possíveis status 
    ///         {
    ///             "Aguardando pagamento": 0,
    ///             "Pagamento Aprovado": 1,
    ///             "Cancelada":2,
    ///             "Enviado para Transportadora":3
    ///             "Entregue":4
    ///         }
    /// </param>
    /// <returns>Retorna venda registrada e informações do vendedor</returns>
    /// <response code="201">Retorna venda registrada</response>
    /// <response code="400">Indica mensagem de falha específica na alteração do recurso</response>
    /// <response code="401">Usuario não autenticado</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
