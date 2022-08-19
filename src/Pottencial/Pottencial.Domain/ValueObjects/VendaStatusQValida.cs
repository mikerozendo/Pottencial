namespace Pottencial.Domain.ValueObjects
{
    public class VendaStatusQValida
    {
        public string AguardandoPagamentoValida => "O status de 'Aguardando Pagamento' só pode dar passo à 'Pagamento Aprovado' ou 'Cancelado'";
        public string PagamentoAprovadoValida => "O status de 'Pagamento aprovado' só pode dar passo à 'Enviado para transportadora' ou Cancelado";
        public string EnviadoParaTransportadoraValida => "O status de 'Enviado para transportadora' só pode dar passo à  'Entregue'";
    }
}
