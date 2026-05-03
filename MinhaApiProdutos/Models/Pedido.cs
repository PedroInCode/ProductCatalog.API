namespace MinhaApiProdutos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json.Serialization;

public class Pedido
{
    [JsonIgnore] // Evita a serialização do ID do pedido, pois pode ser gerado automaticamente pelo banco de dados.
    public int Id { get; set; }
    public int Quantidade { get; set; }

    // DateTime.Now é usado para definir a data e hora atual no momento da criação do pedido.
    [JsonIgnore] // Evita a serialização da data do pedido, pois pode não ser relevante para o cliente.
    public DateTime DataPedido { get; set; } = DateTime.Now;

    // Chave estrangeira para o produto
    public int ProdutoId { get; set; }

    // Propriedade de navegação para o produto
    // ? significa que a propriedade pode ser nula antes de ser carregada.
    [JsonIgnore] // Evita a referência circular durante a serialização JSON
    public Produto? Produto { get; set; } = null!;
}
