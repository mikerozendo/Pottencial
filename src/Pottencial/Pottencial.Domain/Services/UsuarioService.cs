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

    public Usuario Login(Usuario usuario)
    {
        if (usuario is null || String.IsNullOrEmpty(usuario.Email) || String.IsNullOrEmpty(usuario.Senha)) 
            throw new ArgumentNullException("Informe email e senha"); 


        return _usuarioRepository.Login(usuario);
    }
}
