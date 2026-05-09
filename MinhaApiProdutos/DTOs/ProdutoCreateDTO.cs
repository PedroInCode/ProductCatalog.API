using System.ComponentModel.DataAnnotations;

namespace MinhaApiProdutos.DTOs;

public class ProdutoCreateDTO
{


    [Required(ErrorMessage = "O nome do produto é obrigatório.")] 
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do produto deve ter entre 3 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;

    [Range(0.01, 999999, ErrorMessage = "O preço deve ser um valor positivo.")]
    public decimal Preco { get; set; }

    [Range(0, 1000, ErrorMessage = "O estoque deve ser um valor entre 0 e 1000.")]
    public int Estoque { get; set; }
}
