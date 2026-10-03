using Microsoft.AspNetCore.Mvc;
using dvteam_api.Models;
using Microsoft.EntityFrameworkCore;
using dvteam_api.Data;

namespace dvteam_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
	private readonly AppDbContext _context;
	public TarefaController (AppDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> ListarTarefas()
	{
		var Tarefas = await _context.Tarefas.ToListAsync();
		return Ok(Tarefas);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetTarefa(int id)
	{
		if (id <= 0)
		{
			return BadRequest("ID inválido.");
		}

		var tarefa = await _context.Tarefas.FindAsync(id);
		if (tarefa == null)
		{
			return NotFound("Tarefa não encontrada");
		}

		return Ok(tarefa);
	}

	[HttpPost]
	public async Task<IActionResult> CriarTarefa([FromBody] Tarefa tarefa)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		_context.Tarefas.Add(tarefa);
		await _context.SaveChangesAsync();
		return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> AtualizarTarefa(int id, [FromBody] Tarefa tarefaAtualizada)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var tarefa = await _context.Tarefas.FindAsync(id);
		if (tarefa == null)
			return NotFound("Tarefa não encontrada.");

		tarefa.Titulo = tarefaAtualizada.Titulo;
		tarefa.Descricao = tarefaAtualizada.Descricao;
		tarefa.DataConclusao = tarefaAtualizada.DataConclusao;
		tarefa.Status = tarefaAtualizada.Status;
		
		await _context.SaveChangesAsync();
		return Ok($"Tarefa ID: {id} | {tarefaAtualizada.Titulo}, atualizada com sucesso!");
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeletarTarefa(int id)
	{
		var tarefa = await _context.Tarefas.FindAsync(id);
		if (tarefa == null)
			return NotFound("Tarefa não encontrada.");
		
		_context.Tarefas.Remove(tarefa);
		await _context.SaveChangesAsync();

		return Ok("Tarefa deletada.");
	}
}