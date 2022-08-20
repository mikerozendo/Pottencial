namespace Pottencial.Domain.Entities;

public class PedidoItem
{
    public Item Item { get; set; } = new();
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal Frete { get; set; }

    public PedidoItem()
    {
        DefinirValorTotal();
    }

    private void DefinirValorTotal()
    {
        ValorTotal = Item.Valor * Quantidade + Frete;
    }
}
