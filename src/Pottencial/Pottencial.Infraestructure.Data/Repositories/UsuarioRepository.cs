using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repositories;

namespace Pottencial.Infraestructure.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private List<Usuario> usuarios = new();

    public Usuario Login(Usuario usuario)
    {
        var list = Get();
        return list.FirstOrDefault(x => x.Equals(usuario));
    }

    public IEnumerable<Usuario> Get()
    {
        return usuarios;
    }

    public Usuario CriarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
        return usuario;
    }
}
