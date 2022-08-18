using Pottencial.Domain.Exceptions;

namespace Pottencial.Domain.ValueObjects;

public class CPF
{
    public string Cpf { get; private set; }

    public CPF(string cpf)
    {
        Cpf = cpf;
        if (!ValidarCPF()) throw new CpfException();
    }

    private bool ValidarCPF()
    {
        FormatarCPF();
        char[] cpfBase = Cpf.ToCharArray();

        int primeiroDV, segundoDV, somaDv = 0;
        int multiplicador = 10;

        Dictionary<int, int> dictionary = new();

        try
        {
            for (int i = 0; i < cpfBase.Count() - 2; i++)
            {
                dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));
                if (dictionary.TryGetValue(i, out int value))
                {
                    somaDv += value;
                }
                multiplicador -= 1;
            }

            primeiroDV = 11 - (somaDv % 11);
            multiplicador = 11;
            dictionary.Clear();
            somaDv = 0;

            if (primeiroDV.ToString() == cpfBase[9].ToString() ||
                (primeiroDV == 0 && cpfBase[9] == '0') ||
                (primeiroDV == 1 && cpfBase[9] == '0'))
            {
                for (int i = 0; i < cpfBase.Count() - 1; i++)
                {
                    dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));

                    if (dictionary.TryGetValue(i, out int value))
                        somaDv += value;

                    multiplicador -= 1;
                }
                segundoDV = 11 - (somaDv % 11);

                return segundoDV.ToString() == cpfBase[10].ToString() ||
                segundoDV == 0 && cpfBase[10] == '0' ||
                segundoDV == 1 && cpfBase[10] == '0';
            }
            
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private void FormatarCPF()
    {
        if (String.IsNullOrEmpty(Cpf) || ValidarCaracteresIguais())
            throw new CpfException();

        if (Cpf.Contains("."))
            Cpf = Cpf.Replace(".", String.Empty);

        if (Cpf.Contains("-"))
            Cpf = Cpf.Replace("-", String.Empty);
    }

    private bool ValidarCaracteresIguais()
    {
        var array = Cpf.ToCharArray();
        string firstItem = array[0].ToString();
        bool allEqual = array.Skip(1).All(s => string.Equals(firstItem, s.ToString(), StringComparison.InvariantCultureIgnoreCase));
        return allEqual;
    }
}
