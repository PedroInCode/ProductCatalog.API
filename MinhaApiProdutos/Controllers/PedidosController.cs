using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MinhaApiProdutos.Data;
using MinhaApiProdutos.Models;
using Microsoft.IdentityModel.Tokens;

namespace MinhaApiProdutos.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PedidosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PedidosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
    {
        // Passo 1 - Verificar se o produto existe
        var produto = await _context.Produtos.FindAsync(pedido.ProdutoId);

        // Passo 2 - Verificar se o produto foi encontrado
        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        // Passo 3 - Verificar se o estoque é suficiente
        if (produto.Estoque < pedido.Quantidade)
        {
            return BadRequest("Estoque insuficiente para o produto solicitado.");
        }

        // PASSO 4: A "Mágica" da Interligação (Baixar o estoque)
        // Como o 'produto' foi rastreado pelo _context lá no Passo 1, 
        // qualquer mudança nele será salva no banco depois!
        produto.Estoque -= pedido.Quantidade;

        // Passo 5 - Salvar o pedido
        _context.Pedidos.Add(pedido);

        // Passo 6 - Salvar as mudanças no banco (tanto o pedido quanto o estoque atualizado)
        await _context.SaveChangesAsync();

        // Passo 7 - Retornar o pedido criado
        return CreatedAtAction(nameof(PostPedido), new { id = pedido.Id }, pedido);
    }
}
