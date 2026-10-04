using Microsoft.AspNetCore.Mvc;
using dvteam_api.Models;
using dvteam_api.Services;

namespace dvteam_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
	private readonly IUsuarioService _service;
	public UsuarioController(IUsuarioService service)
	{
		_service = service;
	}
    
	[HttpGet("{id}")]
	public async Task<IActionResult> GetUsuario(int id)
	{
		if (id <= 0)
			return BadRequest("ID inválido.");

		var usuario = await _service.GetUsuarioAsync(id);
		if (usuario == null)
			return NotFound("Usuário não encontrado.");

		return Ok(usuario);
	}

    [HttpPost]
	public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
		
		var novoUsuario = await _service.CriarUsuarioAsync(usuario);

		return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.Id }, novoUsuario);
	}
}