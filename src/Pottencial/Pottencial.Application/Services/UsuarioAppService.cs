using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Mappers;
using Pottencial.Domain.Interfaces.Services;

namespace Pottencial.Application.Services;

public class UsuarioAppService : IUsuarioAppService
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioAppService(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public UsuarioLoginViewModel Login(UsuarioLoginViewModel usuario)
    {
        try
        {
            return UsuarioMapper.ToViewModel(_usuarioService.Login(UsuarioMapper.ToDomain(usuario)));
        }
        catch (ArgumentNullException)
        {
            throw;
        }
    }
}
