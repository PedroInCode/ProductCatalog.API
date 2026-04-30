using System.ComponentModel.DataAnnotations;

namespace MinhaApiProdutos.Models;

public class Produto
{
    [Key] // Define a chave primária
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}
