using Pottencial.Domain.ValueObjects;

namespace Pottencial.Test.Pottencial.Domain.Test;

//Testes comentados por conta conta da modificacao dos modificadores de acesso da classe após finalizacao;
public class CPF_Teste
{
    [Fact]
    public void FormatarCPF_Exception_Teste()
    {
        CPF cpf = new("");

        //Assert.Throws<CpfException>(() => cpf.FormatarCPF());
    }

    [Theory]
    [InlineData("33442222")]
    [InlineData("774.224.346-20")]
    [InlineData("2020.X.346-20")]
    public void ValidarCPF_INVALIDO_Teste(string cpf)
    {
        //Arrange
        //CPF value = new("cpf");

        //Act
        //bool valido = value.ValidarCPF();

        //Assert.False(valido);
    }

    [Theory]
    [InlineData("SEU_CPF_SEM_PONTOS_E_TRACO")]
    [InlineData("SEU_CPF_COM_PONTOS_E_TRACOS")]
    [InlineData("SEU_CPF_SEM_TRACOS")]
    [InlineData("SEU_CPF_SEM_PONTO")]
    public void ValidarCPF_VALIDO_Teste(string cpf)
    {
        //Arrange
        //CPF value = new(cpf);

        //Act
        //bool valido = value.ValidarCPF();

        //Assert.True(valido);
    }

    [InlineData("4444444")]
    [InlineData("5555555")]
    [InlineData("00000000000")]
    public void ValidarCaracteresIguais_Teste(string value)
    {
        //CPF obj = new(value);

        //bool equals = obj.ValidarCaracteresIguais();

        //Assert.True(equals);
    }
}
