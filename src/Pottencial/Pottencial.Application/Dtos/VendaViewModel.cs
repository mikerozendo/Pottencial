namespace Pottencial.Application.Dtos
{
    public class VendaViewModel
    {
        public string Produto { get; set; }
        public decimal ProdutoPreco { get; set; }
        public int ProdutoQuantiade { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? Frete { get; set; } = 0;
        public string VendedorNome { get; set; }
        public string VendedorCPF { get; set; }
        public string? VendedorEmail { get; set; } = "";
        public string? VendedorTelefone { get; set; } = "";
        public int? VendedorId { get; set; }
        public int StatusId { get; set; }
        public string? StatusDescricao { get; set; } = "";
        public DateTime? Data { get; set; } = DateTime.Now;
    }
}
