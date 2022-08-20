using Pottencial.Domain.Entities.Utils;
using Pottencial.Domain.Enums;

namespace Pottencial.Domain.Entities;

public class Item
{
    public string Produto { get; private set; }
    public decimal Valor { get; private set; }
    public EnumTipoProduto EnumTipoProduto { get; set; }

    public Item(int enumTipoProduto, decimal valor)
    {
        EnumTipoProduto = Enum.IsDefined((EnumTipoProduto)enumTipoProduto) ? (EnumTipoProduto)enumTipoProduto : EnumTipoProduto.Indefinido;
        Valor = valor;

        DefiniProduto();
    }

    private void DefiniProduto()
    {
        Produto = BaseEnum<EnumTipoProduto>.GetDescription(EnumTipoProduto);
    }
}
