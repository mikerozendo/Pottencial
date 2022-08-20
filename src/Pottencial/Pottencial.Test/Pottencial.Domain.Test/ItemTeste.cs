using Pottencial.Domain.Entities;
using Pottencial.Domain.Enums;

namespace Pottencial.Test.Pottencial.Domain.Test;

public class ItemTeste
{
    [Fact]
    public void Testa_Description_EnumTipoVenda()
    {
        Item item = new(1,0);

        Assert.Equal("Calça jeans", item.Produto);
    }

    [Fact]
    public void Testa_Description_EnumTipoVenda_Bermuda()
    {
        Item item = new(2, 0);

        Assert.Equal("Bermuda jeans", item.Produto);
    }

    [Fact]
    public void Testa_Description_EnumTipoVenda_Camiseta()
    {
        Item item = new(3, 0);

        Assert.Equal("Camiseta", item.Produto);
    }

    [Fact]
    public void Testa_Description_EnumTipoVenda_CortaVento()
    {
        Item item = new(4, 0);

        Assert.Equal("Casaco corta-vento", item.Produto);
    }

    [Fact]
    public void Testa_Description_EnumTipoVenda_Jaqueta()
    {
        Item item = new(5, 0);

        Assert.Equal("Jaqueta de couro", item.Produto);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    public void Testa_Description_EnumTipoVenda_Indefinido(int enumtipoProduto)
    {
        Item item = new(enumtipoProduto,0);

        Assert.Equal("Indefinido", item.Produto);
    }
}
