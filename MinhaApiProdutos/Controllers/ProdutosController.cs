using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MinhaApiProdutos.Data;
using MinhaApiProdutos.Models;
using Microsoft.IdentityModel.Tokens;
using MinhaApiProdutos.DTOs;
using MinhaApiProdutos.Services;

namespace MinhaApiProdutos.Controllers;

    [Route("api/[controller]")]
    [ApiController]

public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service; // Chama a Interface, não o banco.

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    // Primeiro Metodo: GET /api/produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoResponseDTO>>> GetProdutos()
    {
        var produtos = await _service.ObterTodos(); // Chama o método do serviço para obter os produtos.
        return Ok(produtos); // Retorna um status 200 OK com a lista de produtos no formato DTO.
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoResponseDTO>> GetProduto(int id)
    {
        var produto = await _service.ObterPorId(id); // Chama o método do serviço para obter um produto por ID.
        if (produto == null) // Se o produto não for encontrado, retorna um status 404 Not Found.
        {
            return NotFound();
        }
        return Ok(produto); // Retorna um status 200 OK com o produto encontrado.
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoResponseDTO>> PostProduto(ProdutoCreateDTO produtoDto )
    {
        var resultado = await _service.Criar(produtoDto); // Chama o método do serviço para criar um novo produto com os dados fornecidos no DTO.

        return CreatedAtAction(nameof(GetProduto), new { id = resultado.Id }, resultado); // Retorna um status 201 Created, com a localização do novo recurso e o produto criado no formato DTO.
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var deletado = await _service.Deletar(id); // Chama o método do serviço para deletar um produto por ID.
        if (!deletado) // Se a exclusão falhar, retorna um status 404 Not Found.
        {
            return NotFound();
        }
        return NoContent(); // Retorna um status 204 No Content, indicando que a operação foi bem-sucedida, mas não há conteúdo para retornar.
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(int id, ProdutoCreateDTO produtoDto)
    {
        var atualizado = await _service.Atualizar(id, produtoDto); // Chama o método do serviço para atualizar um produto existente com os dados fornecidos.
        if (!atualizado) // Se a atualização falhar, retorna um status 404 Not Found.
        {
            return NotFound();
        }

        return NoContent(); // Retorna um status 204 No Content, indicando que a operação foi bem-sucedida, mas não há conteúdo para retornar.
    }

    
}
