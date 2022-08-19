using Pottencial.Domain.Enums;
using Pottencial.Domain.Exceptions;
using Pottencial.Domain.ValueObjects;

namespace Pottencial.Domain.Entities;

public class Venda : Base
{
    public DateTime Data { get; set; }
    public EnumStatusVenda EnumStatusVenda { get; private set; }
    public PedidoItem PedidoItem { get; set; } 
    public Vendedor Vendedor { get; set; }

    public Venda(EnumStatusVenda enumStatusVenda)
    {
        EnumStatusVenda = enumStatusVenda;
    }

    public void AlterarStatusVendaBuilder(EnumStatusVenda statusCandidato)
    {
        if (ValidaStatusAguardandoPagamento(statusCandidato) || ValidaStatusPagamentoAprovado(statusCandidato) || ValidaStatusEnviadoParaTransportadora(statusCandidato))
            EnumStatusVenda = statusCandidato;

        else 
            ExceptionHandler();
    }

    private bool ValidaStatusAguardandoPagamento(EnumStatusVenda statusCandidato)
    {
        return EnumStatusVenda == EnumStatusVenda.AguardandoPagamento && (statusCandidato == EnumStatusVenda.PagamentoAprovado || statusCandidato == EnumStatusVenda.Cancelada);
    }

    private bool ValidaStatusPagamentoAprovado(EnumStatusVenda statusCandidato)
    {
        return EnumStatusVenda == EnumStatusVenda.PagamentoAprovado && (statusCandidato == EnumStatusVenda.EnviadoParaTransportadora || statusCandidato == EnumStatusVenda.Cancelada);
    }

    private bool ValidaStatusEnviadoParaTransportadora(EnumStatusVenda statusCandidato)
    {
        return EnumStatusVenda == EnumStatusVenda.EnviadoParaTransportadora && statusCandidato == EnumStatusVenda.Entregue;
    }

    private void ExceptionHandler()
    {
        throw new StatusInvalidoException(DefiniMensagemException());
    }

    private string DefiniMensagemException()
    {
        VendaStatusQValida valida = new();

        if (EnumStatusVenda == EnumStatusVenda.AguardandoPagamento)
            return valida.AguardandoPagamentoValida;

        else if (EnumStatusVenda == EnumStatusVenda.EnviadoParaTransportadora)
            return valida.EnviadoParaTransportadoraValida;

        else if (EnumStatusVenda == EnumStatusVenda.PagamentoAprovado)
            return valida.AguardandoPagamentoValida;

        return String.Empty;
    }
}
