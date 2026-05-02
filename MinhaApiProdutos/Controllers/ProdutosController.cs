using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MinhaApiProdutos.Data;
using MinhaApiProdutos.Models;
using Microsoft.IdentityModel.Tokens;

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
        produto.Id = 0; // Garante que o Id seja 0 para que o Entity Framework gere um novo Id automaticamente.

        // O Entity Framework "anota" que esse produto deve ser adicionado ao banco de dados.
        _context.Produtos.Add(produto);

        // Ele gera o comando SQL para inserir o produto e executa esse comando no banco de dados.
        await _context.SaveChangesAsync();

        // Retorna o status 201 Created e mostra que o produto foi criado.
        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id); // Busca o produto no banco de dados pelo Id.

        if (produto == null) // Se o produto não for encontrado, retorna um status 404 Not Found.
        {
            return NotFound();
        }

        _context.Produtos.Remove(produto); // O Entity Framework "anota" que esse produto deve ser removido do banco de dados.
        //Ele gera o comando SQL para deletar o produto e executa esse comando no banco de dados.

        await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados.

        return NoContent(); // Retorna um status 204 No Content, indicando que a operação foi bem-sucedida, mas não há conteúdo para retornar.
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(int id, Produto produto)
    {
        if (id != produto.Id) // verifica se o id da URL corresponde ao id do produto no corpo da requisição.
        {
            return BadRequest("O ID do produto na URl não coincide com o ID do produto!"); // Se não corresponder, retorna um status 400 Bad Request.
        }

        _context.Entry(produto).State = EntityState.Modified; // O Entity Framework "anota" que esse produto foi modificado e deve ser atualizado no banco de dados.

        try
        {
            // Tenta salvar as mudanças no banco de dados.
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) // Tenta salvar as mudanças no banco de dados. Se ocorrer uma exceção de concorrência, verifica se o produto ainda existe.
        {
            // Caso alguem tenha deletado o produto enquanto você estava tentando editar.
            if (!ProdutoExists(id))// Se o produto não existir mais, retorna um status 404 Not Found.
            {
                return NotFound();
            }
            else
            {
                throw; // Se o produto ainda existir, relança a exceção para que ela seja tratada em outro lugar.
            }
        }
        return NoContent(); // Retorna um status 204 No Content, indicando que a operação foi bem-sucedida, mas não há conteúdo para retornar.
    }

    private bool ProdutoExists(int id)
    {
        return _context.Produtos.Any(e => e.Id == id); // Verifica se existe algum produto com o id fornecido no banco de dados.
    }
}
