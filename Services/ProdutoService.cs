using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Repositories;

namespace MinhaPrimeiraApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<List<Produto>> ListarTodosAsync()
    {
        return await _produtoRepository.ListarTodosAsync();
    }

    public async Task<Produto?> BuscarPorIdAsync(int id)
    {
        return await _produtoRepository.BuscarPorIdAsync(id);
    }

    public async Task<Produto> CriarAsync(Produto produto)
    {
        if(produto.Preco < 0.01m)
        {
            throw new ArgumentException("O preço do produto deve ser maior que zero.");
        }

        if(await _produtoRepository.ExisteNomeDuplicadoAsync(produto.Nome))
        {
            throw new ArgumentException($"Já existe um produto com o nome '{produto.Nome}'.");
        }
        
        return await _produtoRepository.CriarAsync(produto);
    }

    public async Task<Produto?> AtualizarAsync(int id, Produto produtoAtualizado)
    {
        return await _produtoRepository.AtualizarAsync(id, produtoAtualizado);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        return await _produtoRepository.RemoverAsync(id);
    }
}