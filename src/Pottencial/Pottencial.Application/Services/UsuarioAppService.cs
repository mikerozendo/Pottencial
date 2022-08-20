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

    public UsuarioLoginViewModel? CriarUsuario(UsuarioLoginViewModel usuario)
    {
        if (String.IsNullOrEmpty(usuario.Email) || String.IsNullOrEmpty(usuario.Senha)) return null;

        return UsuarioMapper.ToViewModel(_usuarioService.CriarUsuario(UsuarioMapper.ToDomain(usuario)));
    }

    public bool Login(UsuarioLoginViewModel usuario)
    {
        return _usuarioService.Login(UsuarioMapper.ToDomain(usuario));
    }
}
