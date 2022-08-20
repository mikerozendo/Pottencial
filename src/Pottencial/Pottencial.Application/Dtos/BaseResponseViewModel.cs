namespace Pottencial.Application.Dtos;

public class BaseResponseViewModel
{
    public int HttpStatus { get; set; }
    public string Mensagem { get; set; }

    public BaseResponseViewModel(int httpStatus, string mensagem)
    {
        HttpStatus = httpStatus;
        Mensagem = mensagem;
    }
}
