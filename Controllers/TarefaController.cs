using Microsoft.AspNetCore.Mvc;
using dvteam_api.Models;
namespace dvteam_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
	[HttpGet]
	public IActionResult ListarTarefas()
	{
		return Ok();
	}

	[HttpGet("{id}")]
	public IActionResult GetTarefa(int id)
	{
		if (id <= 0)
		{
			return BadRequest("ID inválido.");
		}
		return Ok();
	}

	[HttpPost]
	public IActionResult CriarTarefa([FromBody] Tarefa tarefa)
	{
		return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
	}
}