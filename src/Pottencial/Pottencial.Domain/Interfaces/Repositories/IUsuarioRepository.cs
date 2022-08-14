using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Usuario Login(Usuario usuario);
}
