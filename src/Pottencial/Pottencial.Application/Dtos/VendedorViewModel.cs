using System.ComponentModel.DataAnnotations;

namespace Pottencial.Application.Dtos;

public class VendedorViewModel
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Telefone { get; set; }

    [Required]
    public string Cpf { get; set; }
}
