using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MinhaApiProdutos.Data;
using MinhaApiProdutos.Models;

namespace MinhaApiProdutos.Controllers;

    [Route("api/[controller]")]
    [ApiController]

public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    // Primeiro Metodo: GET /api/produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto )
    {
        // O Entity Framework "anota" que esse produto deve ser adicionado ao banco de dados.
        _context.Produtos.Add(produto);

        // Ele gera o comando SQL para inserir o produto e executa esse comando no banco de dados.
        await _context.SaveChangesAsync();

        // Retorna o status 201 Created e mostra que o produto foi criado.
        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }
}
