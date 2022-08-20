using Pottencial.Application.Dtos.Adapters;

namespace Pottencial.Application.Dtos.Reponses;

public class VendedorErrorViewModel : ErrorViewModel
{
    public VendedorViewModel RecursoExistente { get; set; }

    public VendedorErrorViewModel(int httpStatus, string message) : base(httpStatus, message) { }
}
