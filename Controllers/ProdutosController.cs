using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Services;

namespace MinhaPrimeiraApi.Controllers;

[ApiController]

[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{

    private readonly IProdutoService _service;
    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var produtos = await _service.ListarTodosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        if (id <= 0)
        {
            return BadRequest("O id do produto deve ser maior que zero.");
        }

        var produto = await _service.BuscarPorIdAsync(id);

        if (produto == null)
        {
            return NotFound($"Produto com id {id} não encontrado.");
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var criado = await _service.CriarAsync(produto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = criado.Id }, criado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produtoAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoExistente = await _service.AtualizarAsync(id, produtoAtualizado);

            if (produtoExistente == null)
            {
                return NotFound($"Produto com id {id} não encontrado.");
            }

            return Ok($"Produto com id {id} atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var removido = await _service.RemoverAsync(id);

            if (!removido)
            {
                return NotFound($"Produto com id {id} não encontrado.");
            }

            return NoContent();
        }
    }
}