using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Services;

public interface IUsuarioService
{
    Usuario Login(Usuario usuario);
}
