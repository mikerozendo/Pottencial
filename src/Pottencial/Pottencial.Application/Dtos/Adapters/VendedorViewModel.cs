using Pottencial.Application.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace Pottencial.Application.Dtos.Adapters;

public class VendedorViewModel : BaseViewModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
}
