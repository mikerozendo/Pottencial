using Pottencial.Application.Dtos;

namespace Pottencial.Application.Interfaces;

public interface IUsuarioAppService
{
    UsuarioLoginViewModel Login(UsuarioLoginViewModel usuario);
}
