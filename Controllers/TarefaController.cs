using Microsoft.AspNetCore.Mvc;
using dvteam_api.Models;

namespace dvteam_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
	private readonly ITarefaService _service;
	public TarefaController(ITarefaService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> ListarTarefas()
	{
		var tarefas = await _service.ListarTarefasAsync();
		return Ok(tarefas);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetTarefa(int id)
	{
		if (id <= 0)
			return BadRequest("ID inválido.");

		var tarefa = await _service.GetTarefaAsync(id);
		if (tarefa == null)
			return NotFound("Tarefa não encontrada");

		return Ok(tarefa);
	}

	[HttpPost]
	public async Task<IActionResult> CriarTarefa([FromBody] Tarefa tarefa)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var novaTarefa = await _service.CriarTarefaAsync(tarefa);

		return CreatedAtAction(nameof(GetTarefa), new { id = novaTarefa.Id }, novaTarefa);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> AtualizarTarefa(int id, [FromBody] Tarefa tarefaAtualizada)
	{
		if (id <= 0)
			return BadRequest("ID inválido.");

		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var tarefa = await _service.AtualizarTarefaAsync(id, tarefaAtualizada);
		if (tarefa == null)
			return NotFound("Tarefa não encontrada.");

		return Ok($"Tarefa ID: {id} | {tarefaAtualizada.Titulo}, atualizada com sucesso!");
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeletarTarefa(int id)
	{
		if (id <= 0)
			return BadRequest("ID inválido.");

		var tarefaDeletada = await _service.DeletarTarefaAsync(id);
		if (!tarefaDeletada)
			return NotFound("Tarefa não encontrada.");

		return Ok("Tarefa deletada.");
	}
}