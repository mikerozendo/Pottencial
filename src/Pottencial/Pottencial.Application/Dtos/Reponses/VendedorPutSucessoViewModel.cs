using Pottencial.Application.Dtos.Adapters;
using Pottencial.Application.Dtos.Base;

namespace Pottencial.Application.Dtos.Reponses;

public class VendedorPutSucessoViewModel : BaseResponseViewModel
{
    public VendedorViewModel VendedorAlterado { get; set; }

    public VendedorPutSucessoViewModel(int httpStatus, string message) : base(httpStatus, message) { }
}
