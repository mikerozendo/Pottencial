using Pottencial.Application.Dtos.Adapters;

namespace Pottencial.Application.Interfaces;

public interface IUsuarioAppService
{
    bool Login(UsuarioLoginViewModel usuario);
    UsuarioLoginViewModel? CriarUsuario(UsuarioLoginViewModel usuario);
}
