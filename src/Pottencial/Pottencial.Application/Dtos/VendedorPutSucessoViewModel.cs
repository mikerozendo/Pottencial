namespace Pottencial.Application.Dtos;

public class VendedorPutSucessoViewModel : BaseResponseViewModel
{
    public VendedorViewModel VendedorAlterado { get; set; }

    public VendedorPutSucessoViewModel(int httpStatus, string message) : base(httpStatus, message){ }
}
