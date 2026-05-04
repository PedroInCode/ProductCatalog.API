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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePedido(int id)
    {
        // Busca o pedido para saber o que foi vendido.
        var pedido = await _context.Pedidos.FindAsync(id);

        // Verifica se o pedido existe.
        if (pedido == null)
        {
            return NotFound("Pedido não encontrado!!");
        }
        
        // Busca o id do produto do pedido para realizar a restauração do estoque.
        var produto = await _context.Produtos.FindAsync(pedido.ProdutoId);

        // Se o produto não for nulo, a operação para restaurar o estoque é feita.
        if (produto != null)
        {
            produto.Estoque += pedido.Quantidade;
        }

        //Acessa a tabela de pedidos no banco e remove o pedido pelo id.
        _context.Pedidos.Remove(pedido);

        // Salva as alterações ( Pedido delatado e Estoque do produto restaurado.
        await _context.SaveChangesAsync();

        // Avisa que tudo deu certo, porem não tem nada para retornar.
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetTodosPedidos()
    {
        return await _context.Pedidos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> GetPedido(int id)
    {
        var pedido = await _context.Pedidos.Include(pedido => pedido.Produto) //Traga os dados do Produto junto!
            .FirstOrDefaultAsync(pedido => pedido.Id == id); // Onde o id do pedido seja igual ao id que recebi.

        if (pedido == null)
        {
            return NotFound("Pedido não encontrado!!");
        }

        return Ok(pedido);
    }
}
