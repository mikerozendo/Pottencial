using Pottencial.Application.Dtos.Base;

namespace Pottencial.Application.Dtos.Reponses;

public class ErrorViewModel : BaseResponseViewModel
{
    public ErrorViewModel(int httpStatus, string mensagem) : base(httpStatus, mensagem) { }
}
