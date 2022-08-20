namespace Pottencial.Domain.Exceptions;

public class VendaSemItensException : Exception
{
    public VendaSemItensException():base("O itém do pedido não pode ser de quantidade 0"){ }
}
