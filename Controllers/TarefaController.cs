using Microsoft.AspNetCore.Mvc;
using dvteam_api.Models;
using dvteam_api.Services;
using dvteam_api.DTOs;

namespace dvteam_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefaController(ITarefaService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todas as tarefas cadastradas.
    /// </summary>
    /// <returns>Lista de tarefas cadastradas.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Tarefa>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarTarefas()
    {
        var tarefas = await _service.ListarTarefasAsync();

        return Ok(tarefas);
    }

    /// <summary>
    /// Busca uma tarefa pelo identificador.
    /// </summary>
    /// <param name="id">Identificador da tarefa.</param>
    /// <returns>A tarefa encontrada.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Tarefa), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTarefa(int id)
    {
        if (id <= 0)
            return BadRequest(new
            {
                mensagem = "O ID informado é inválido."
            });

        var tarefa = await _service.GetTarefaAsync(id);

        if (tarefa == null)
            return NotFound(new
            {
                mensagem = "Tarefa não encontrada."
            });

        return Ok(tarefa);
    }

    /// <summary>
    /// Cria uma nova tarefa.
    /// </summary>
    /// <param name="tarefa">Dados da tarefa que será cadastrada.</param>
    /// <returns>A tarefa criada.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Tarefa), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarTarefa([FromBody] Tarefa tarefa)
    {
        var novaTarefa = await _service.CriarTarefaAsync(tarefa);

        return CreatedAtAction(
            nameof(GetTarefa),
            new { id = novaTarefa.Id },
            novaTarefa
        );
    }

    /// <summary>
    /// Atualiza uma tarefa existente.
    /// </summary>
    /// <param name="id">Identificador da tarefa.</param>
    /// <param name="tarefaAtualizada">Novos dados da tarefa.</param>
    /// <returns>A tarefa atualizada.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Tarefa), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarTarefa(
        int id,
        [FromBody] Tarefa tarefaAtualizada)
    {
        if (id <= 0)
            return BadRequest(new
            {
                mensagem = "O ID informado é inválido."
            });

        var tarefa = await _service.AtualizarTarefaAsync(
            id,
            tarefaAtualizada
        );

        if (tarefa == null)
            return NotFound(new
            {
                mensagem = "Tarefa não encontrada."
            });

        return Ok(tarefa);
    }

    /// <summary>
    /// Exclui uma tarefa pelo identificador.
    /// </summary>
    /// <param name="id">Identificador da tarefa que será excluída.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletarTarefa(int id)
    {
        if (id <= 0)
            return BadRequest(new
            {
                mensagem = "O ID informado é inválido."
            });

        var tarefaDeletada = await _service.DeletarTarefaAsync(id);

        if (!tarefaDeletada)
            return NotFound(new
            {
                mensagem = "Tarefa não encontrada."
            });

        return NoContent();
    }
}