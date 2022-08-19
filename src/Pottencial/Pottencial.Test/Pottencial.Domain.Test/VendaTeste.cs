using Pottencial.Domain.Entities;
using Pottencial.Domain.Enums;
using Pottencial.Domain.Exceptions;

namespace Pottencial.Test.Pottencial.Domain.Test;

public class VendaTeste
{
    [Theory]
    [InlineData(EnumStatusVenda.EnviadoParaTransportadora)]
    [InlineData(EnumStatusVenda.Entregue)]
    public void Teste_Exception_Alteracao_Status_Aguardando_Pagamento(EnumStatusVenda candidato)
    {
        //De: Aguardando pagamento Para: Pagamento Aprovado
        //De: Aguardando pagamento Para: Cancelada

        Venda venda = new(EnumStatusVenda.AguardandoPagamento);

        Assert.Throws<StatusInvalidoException>(() => venda.AlterarStatusVendaBuilder(candidato));
    }

    [Theory]
    [InlineData(EnumStatusVenda.AguardandoPagamento)]
    [InlineData(EnumStatusVenda.Entregue)]
    public void Teste_Exception_Alteracao_Status_Pagamento_Aprovado(EnumStatusVenda candidato)
    {
        //De: Pagamento Aprovado Para: Enviado para Transportadora
        //De: Pagamento Aprovado Para: Cancelada

        Venda venda = new(EnumStatusVenda.PagamentoAprovado);

        Assert.Throws<StatusInvalidoException>(() => venda.AlterarStatusVendaBuilder(candidato));
    }

    [Theory]
    [InlineData(EnumStatusVenda.AguardandoPagamento)]
    [InlineData(EnumStatusVenda.PagamentoAprovado)]
    [InlineData(EnumStatusVenda.Cancelada)]
    public void Teste_Exception_Alteracao_Status_Enviado_Transportadora(EnumStatusVenda candidato)
    {
        //De: Enviado para Transportador. Para: Entregue

        Venda venda = new(EnumStatusVenda.EnviadoParaTransportadora);

        Assert.Throws<StatusInvalidoException>(() => venda.AlterarStatusVendaBuilder(candidato));
    }

    [Theory]
    [InlineData(EnumStatusVenda.PagamentoAprovado)]
    [InlineData(EnumStatusVenda.Cancelada)]
    [InlineData(EnumStatusVenda.AguardandoPagamento)]
    public void Teste_Alteracao_Status_Aguardando_Pagamento(EnumStatusVenda candidato)
    {
        //Arrange
        Venda venda = new(EnumStatusVenda.AguardandoPagamento);

        //ACT
        venda.AlterarStatusVendaBuilder(candidato);

        //Assert
        Assert.Equal(venda.EnumStatusVenda, candidato);
    }

    [Theory]
    [InlineData(EnumStatusVenda.PagamentoAprovado)]
    [InlineData(EnumStatusVenda.EnviadoParaTransportadora)]
    [InlineData(EnumStatusVenda.Cancelada)]
    public void Teste_Alteracao_Status_Pagamento_Aprovado(EnumStatusVenda candidato)
    {
        //Arrange
        Venda venda = new(EnumStatusVenda.PagamentoAprovado);

        //ACT
        venda.AlterarStatusVendaBuilder(candidato);

        //Assert
        Assert.Equal(venda.EnumStatusVenda, candidato);
    }

    [Theory]
    [InlineData(EnumStatusVenda.Entregue)]
    [InlineData(EnumStatusVenda.EnviadoParaTransportadora)]
    public void Teste_Alteracao_Status_Enviado_Para_Transportadora(EnumStatusVenda candidato)
    {
        //Arrange
        Venda venda = new(EnumStatusVenda.EnviadoParaTransportadora);

        //ACT
        venda.AlterarStatusVendaBuilder(candidato);

        //Assert
        Assert.Equal(venda.EnumStatusVenda, candidato);
    }

    [Fact]
    public void Testa_Descricao_Enum_Status_AguardandoPagamento()
    {
        //Arrange
        Venda venda = new(EnumStatusVenda.AguardandoPagamento);

        //Assert
        Assert.Equal("Aguardando pagamento",venda.EnumStatusVendaDescription);
    }


    [Fact]
    public void Testa_Descricao_Enum_Status_PagamentoAprovado()
    {
        //Arrange
        Venda venda = new(EnumStatusVenda.PagamentoAprovado);

        //Assert
        Assert.Equal("Pagamento Aprovado", venda.EnumStatusVendaDescription);
    }

    [Fact]
    public void Testa_Descricao_Enum_Status_Cancelada()
    {
        //Arrange
        Venda venda = new(EnumStatusVenda.Cancelada);

        //Assert
        Assert.Equal("Cancelada", venda.EnumStatusVendaDescription);
    }

    [Fact]
    public void Testa_Descricao_Enum_Status_Entregue()
    {
        //Arrange
        Venda venda = new(EnumStatusVenda.Entregue);

        //Assert
        Assert.Equal("Entregue", venda.EnumStatusVendaDescription);
    }
}
