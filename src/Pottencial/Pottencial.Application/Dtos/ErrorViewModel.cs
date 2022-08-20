namespace Pottencial.Application.Dtos;

public class ErrorViewModel
{
    public int HttpStatus { get; set; }
    public string Mensagem { get; set; }

    public ErrorViewModel(int httpStatus, string mensagem)
    {
        HttpStatus = httpStatus;
        Mensagem = mensagem;
    }
}
