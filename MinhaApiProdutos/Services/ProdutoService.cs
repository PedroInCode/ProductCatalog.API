using MinhaApiProdutos.Models;
using MinhaApiProdutos.DTOs;
using Microsoft.EntityFrameworkCore;
using MinhaApiProdutos.Data;

namespace MinhaApiProdutos.Services;

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProdutoResponseDTO>> ObterTodos()
    {
        var produtos = await _context.Produtos.ToListAsync();
        return produtos.Select(p => new ProdutoResponseDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Preco = p.Preco
        });
    }

    public async Task<ProdutoResponseDTO> Criar(ProdutoCreateDTO dto )
    {
        var produto = new Produto
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Preco = dto.Preco,
            Estoque = dto.Estoque
        };

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return new ProdutoResponseDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco
        };
    }
}
