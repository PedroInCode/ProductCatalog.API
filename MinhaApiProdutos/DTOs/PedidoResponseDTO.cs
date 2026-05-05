namespace MinhaApiProdutos.DTOs;

public class PedidoResponseDTO
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public int ProdutoId { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }

}
