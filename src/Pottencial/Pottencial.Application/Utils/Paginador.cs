using System.Globalization;

namespace Pottencial.Application.Utils;
public class Paginador<T>
{
    public int QuantidadeMaximaItens => 10;

    public int ObterQuantidadePaginas(IEnumerable<T> listagem)
    {
        if (listagem.Count() <= QuantidadeMaximaItens) return 1;

        int quantiadeItens = ObterQuantidadeItens(listagem);
        decimal quociente = ObterQuocientePaginas(quantiadeItens, QuantidadeMaximaItens);

        bool decimalMaiorQZero = int.TryParse(ObterValorDecimal(quociente), out int value);

        return decimalMaiorQZero ? ((int)(quociente + 1)) : ((int)quociente);
    }

    private int ObterQuantidadeItens(IEnumerable<T> listagem)
    {
        return listagem.ToList().Count;
    }

    private decimal ObterQuocientePaginas(int quantidadeItens, int quantidadeMaximItens)
    {
        return (decimal)quantidadeItens / (decimal)quantidadeMaximItens;
    }

    private string ObterValorDecimal(decimal quociente)
    {
        return quociente.ToString("F2", CultureInfo.InvariantCulture).Split('.')[1];
    }
}
