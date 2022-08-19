using System.ComponentModel;

namespace Pottencial.Domain.Enums;

public enum EnumStatusVenda
{
    [Description("Aguardando pagamento")]
    AguardandoPagamento = 0,

    [Description("Pagamento Aprovado")]
    PagamentoAprovado = 1,

    [Description("Cancelada")]
    Cancelada = 2,

    [Description("Enviado para Transportadora")]
    EnviadoParaTransportadora = 3,

    [Description("Entregue")]
    Entregue = 4
}
