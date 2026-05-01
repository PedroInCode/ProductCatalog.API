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
}
