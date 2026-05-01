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
}
