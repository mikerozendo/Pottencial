using System.ComponentModel;

namespace Pottencial.Domain.Enums;

public enum EnumTipoProduto
{
    [Description("Indefinido")]
    Indefinido = 0,

    [Description("Calça jeans")]
    CalcaJeans = 1,

    [Description("Bermuda jeans")]
    BermudaJeans = 2,

    [Description("Camiseta")]
    Camiseta = 3,

    [Description("Casaco corta-vento")]
    CortaVento = 4,

    [Description("Jaqueta de couro")]
    JaquetaCouro = 5,
}
