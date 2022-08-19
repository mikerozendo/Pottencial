namespace Pottencial.Domain.Exceptions
{
    public class CpfException : Exception
    {
        public CpfException() : base("Por favor informe um CPF válido!") { }
    }
}
