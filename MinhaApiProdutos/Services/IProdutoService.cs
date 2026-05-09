using MinhaApiProdutos.DTOs;

namespace MinhaApiProdutos.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoResponseDTO>> ObterTodos(); // Método para obter todos os produtos
    Task<ProdutoResponseDTO> Criar(ProdutoCreateDTO dto); // Método para criar um novo produto
    Task<ProdutoResponseDTO> ObterPorId(int id); // Método para obter um produto por ID
    Task<bool> Deletar(int id); // Método para deletar um produto por ID
    Task<bool> Atualizar(int id, ProdutoCreateDTO dto); // Método para atualizar um produto por ID
}
