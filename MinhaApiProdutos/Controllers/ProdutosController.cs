using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MinhaApiProdutos.Data;
using MinhaApiProdutos.Models;
using Microsoft.IdentityModel.Tokens;
using MinhaApiProdutos.DTOs;

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
    public async Task<ActionResult<IEnumerable<ProdutoResponseDTO>>> GetProdutos()
    {
        var produtos = await _context.Produtos.ToListAsync(); // Busca todos os produtos no banco de dados.

        var produtosDTO = produtos.Select(p => new ProdutoResponseDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Preco = p.Preco

        }).ToList();

        return Ok(produtosDTO); // Retorna um status 200 OK e a lista de produtos no formato DTO.
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
    public async Task<ActionResult<ProdutoResponseDTO>> PostProduto(ProdutoCreateDTO produtoDto )
    {
        // mapeando o DTO para a entidade Produto
        var novoProduto = new Produto
        {
            Nome = produtoDto.Nome,
            Descricao = produtoDto.Descricao,
            Preco = produtoDto.Preco,
            Estoque = produtoDto.Estoque
        };

        // O Entity Framework "anota" que esse produto deve ser adicionado ao banco de dados.
        _context.Produtos.Add(novoProduto);

        // Ele gera o comando SQL para inserir o produto e executa esse comando no banco de dados.
        await _context.SaveChangesAsync();

        // Preparando a resposta
        var responseDto = new ProdutoResponseDTO
        {
            Id = novoProduto.Id,
            Nome = novoProduto.Nome,
            Descricao = novoProduto.Descricao,
            Preco = novoProduto.Preco
        };

        return CreatedAtAction(nameof(GetProduto), new { id = novoProduto.Id }, responseDto); // Retorna um status 201 Created, com a localização do novo recurso e o produto criado no formato DTO.
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
