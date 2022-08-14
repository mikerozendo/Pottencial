using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repositories;
using Pottencial.Domain.Interfaces.Services;

namespace Pottencial.Domain.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public bool Login(Usuario usuario)
    {
        var user = _usuarioRepository.Login(usuario);
        if (user is null) return false;

        return true;
    }

    public Usuario CriarUsuario(Usuario usuario)
    {
        return _usuarioRepository.CriarUsuario(usuario);
    }
}
