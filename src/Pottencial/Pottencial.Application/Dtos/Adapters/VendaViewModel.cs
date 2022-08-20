namespace Pottencial.Application.Dtos.Adapters;

public class VendaViewModel : VendaPedidoViewModel
{
    public string Produto { get; set; }
    public decimal? ValorTotal { get; set; }
    public int StatusId { get; set; }
    public string? StatusDescricao { get; set; } = "";
    public DateTime? Data { get; set; } = DateTime.Now;
    public DateTime UltimaAlteracao { get; set; }
}
