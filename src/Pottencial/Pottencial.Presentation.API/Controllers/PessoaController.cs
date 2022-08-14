using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Interfaces;

namespace Pottencial.Presentation.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PessoaController : AppBaseController
{
    private readonly IPessoaAppService _pessoaAppService;

    public PessoaController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _pessoaAppService = (IPessoaAppService)GetService(typeof(IPessoaAppService));
    }

    [HttpGet]
    [Route(nameof(Get))]
    public IActionResult Get()
    {
        var list = _pessoaAppService.Get();

        if (list is null)
            return NotFound("Nenhum Registro Encontrado");

        return Ok(list);
    }
}

