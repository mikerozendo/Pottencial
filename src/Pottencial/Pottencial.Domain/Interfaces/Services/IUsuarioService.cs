using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Services;

public interface IUsuarioService
{
    bool Login(Usuario usuario);
    Usuario CriarUsuario(Usuario usuario);
}
