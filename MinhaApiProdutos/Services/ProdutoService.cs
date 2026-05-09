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

    public async Task<ProdutoResponseDTO> Criar(ProdutoCreateDTO dto)
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

    public async Task<ProdutoResponseDTO?> ObterPorId(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        
        if (produto == null)
            return null; // Produto não encontrado

        return new ProdutoResponseDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco
        };
    }

    public async Task<bool> Atualizar(int id, ProdutoCreateDTO dto)
    {
        // Busca o produto existente pelo ID
        var produtoExistente = await _context.Produtos.FindAsync(id);

        // Verifica se o produto existe
        if (produtoExistente == null)
        {
            return false; // Produto não encontrado
        }

        // Atualiza as propriedades do produto existente com os valores do DTO
        produtoExistente.Nome = dto.Nome;
        produtoExistente.Descricao = dto.Descricao;
        produtoExistente.Preco = dto.Preco;
        produtoExistente.Estoque = dto.Estoque;

        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
        return true; // Atualização bem-sucedida
    }

    public async Task<bool> Deletar(int id)
    {
        // Busca o produto pelo ID
        var produto = await _context.Produtos.FindAsync(id);

        // Verifica se o produto existe
        if (produto == null)
            return false; // Produto não encontrado

        // Remove o produto do contexto e salva as alterações
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return true; // Deleção bem-sucedida
    }
}
