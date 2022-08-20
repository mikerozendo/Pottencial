namespace Pottencial.Domain.ValueObjects
{
    public static class VendaStatusQValida
    {
        public static string AguardandoPagamentoValida => "O status de 'Aguardando Pagamento' só pode dar passo à 'Pagamento Aprovado' ou 'Cancelado'";
        public static string PagamentoAprovadoValida => "O status de 'Pagamento aprovado' só pode dar passo à 'Enviado para transportadora' ou Cancelado";
        public static string EnviadoParaTransportadoraValida => "O status de 'Enviado para transportadora' só pode dar passo à  'Entregue'";
        public static string NaoIdentificado => "Essa alteração de status não é permitida";
    }
}
