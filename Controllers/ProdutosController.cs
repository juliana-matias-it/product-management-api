using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Data;

namespace MinhaPrimeiraApi.Controllers;

[ApiController]

[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var produtos = await _context.Produtos.ToListAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        if(id <=0)
        {
            return BadRequest("O id do produto deve ser maior que zero.");
        }
       
       var produto = await _context.Produtos.FindAsync(id);

        if(produto == null)
        {
            return NotFound($"Produto com id {id} não encontrado.");
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] Produto produto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return Ok($"Produto '{produto.Nome}' criado com sucesso.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar (int id, [FromBody] Produto produtoAtualizado)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var produtoExistente = await _context.Produtos.FindAsync(id);

        if(produtoExistente == null)
        {
            return NotFound($"Produto com id {id} não encontrado.");
        }

        produtoExistente.Nome = produtoAtualizado.Nome;
        produtoExistente.Preco = produtoAtualizado.Preco;

        await _context.SaveChangesAsync();
      
        return Ok($"Produto com id {id} atualizado com sucesso.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var produtoExistente = await _context.Produtos.FindAsync(id);

        if(produtoExistente == null)
        {
            return NotFound($"Produto com id {id} não encontrado.");
        }

        _context.Produtos.Remove(produtoExistente);
        await _context.SaveChangesAsync();

        return Ok($"Produto com id {id} deletado com sucesso.");
    }
}