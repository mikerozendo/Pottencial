namespace Pottencial.Domain.ValueObjects;

public class CPF
{
    public string Cpf { get; }
    public CPF(string cpf)
    {
        Cpf = cpf;
        FormatarCPF();
    }

    private void FormatarCPF()
    {
        if(String.IsNullOrEmpty(Cpf))
            throw new ArgumentException("Por favor informe um Cpf");

        if (Cpf.Contains("."))
            Cpf.Replace(".", String.Empty);

        if (Cpf.Contains("-"))
            Cpf.Replace("-", String.Empty);

        if(Cpf.Length != 11)
            throw new ArgumentException("Por favor informe um Cpf");

        if(ValidarCPF(Cpf))
            throw new ArgumentException("Por favor informe um Cpf Válido");
    }

    private bool ValidarCPF(string cpf)
    {
        char[] cpfBase = cpf.ToCharArray();

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
            else return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
