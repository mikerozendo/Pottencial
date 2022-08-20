namespace Pottencial.Domain.Entities;

public class PedidoItem
{
    public Item Item { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal Frete { get; set; }

    public PedidoItem(int idProduto, decimal valorProduto, int quantidade, decimal frete)
    {
        Item = new(idProduto, valorProduto);
        Quantidade = quantidade;
        Frete = frete;

        DefinirValorTotal();
    }

    private void DefinirValorTotal()
    {
        ValorTotal = Item.Valor * Quantidade + Frete;
    }
}
