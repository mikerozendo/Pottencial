using Pottencial.Domain.Entities;

namespace Pottencial.Test.Pottencial.Domain.Test;

public class PedidoItemTeste
{
    [Fact]
    public void ValorTotalPedido_Teste1()
    {
        PedidoItem pedidoItem = new(1, 50, 3, 10);

        Assert.Equal(160, pedidoItem.ValorTotal);
    }

    [Fact]
    public void ValorTotalPedido_Teste2()
    {
        PedidoItem pedidoItem = new(1, 42, 2, 0);

        Assert.Equal(84, pedidoItem.ValorTotal);
    }

    [Fact]
    public void ValorTotalPedido_Teste3()
    {
        PedidoItem pedidoItem = new(1, 24.2m, 3, 0);

        Assert.Equal(72.6m, pedidoItem.ValorTotal);
    }


    [Fact]
    public void ValorTotalPedido_Teste4()
    {
        PedidoItem pedidoItem = new(1, 24.2m, 5, 32);

        Assert.Equal(153, pedidoItem.ValorTotal);
    }

    [Fact]
    public void ValorTotalPedido_Teste5()
    {
        PedidoItem pedidoItem = new(1, 0, 3, 10);

        Assert.Equal(10, pedidoItem.ValorTotal);
    }

    [Fact]
    public void ValorTotalPedido_Teste6()
    {
        PedidoItem pedidoItem = new(1, 332, 7, 0);

        Assert.Equal(2324, pedidoItem.ValorTotal);
    }
}
