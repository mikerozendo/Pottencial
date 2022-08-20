namespace Pottencial.Application.Dtos;

public class VendedorErrorViewModel : ErrorViewModel
{
    public VendedorViewModel RecursoExistente { get; set; }

    public VendedorErrorViewModel(int httpStatus, string message) : base(httpStatus, message){ }
}
