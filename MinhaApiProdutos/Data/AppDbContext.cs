namespace MinhaApiProdutos.Data;
using Microsoft.EntityFrameworkCore;
using MinhaApiProdutos.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; } // Aqui voce diz que quer uma tabela de Produtos baseada na sua Models.
}
