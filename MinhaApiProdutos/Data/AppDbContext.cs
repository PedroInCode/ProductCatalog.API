namespace MinhaApiProdutos.Data;
using Microsoft.EntityFrameworkCore;
using MinhaApiProdutos.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // É o "fio de energia". Ele permite que as configurações de conexão (que estão em outro arquivo ) entrem aqui para ligar o banco.
    }

    public DbSet<Produto> Produtos { get; set; } // Aqui voce diz que quer uma tabela de Produtos baseada na sua Models.
    public DbSet<Pedido> Pedidos { get; set; } //Aqui voce diz que quer uma tabela de Pedidos baseada na sua Models.
}
