using Microsoft.AspNetCore.Mvc;
using dvteam_api.Models;
using Microsoft.EntityFrameworkCore;
using dvteam_api.Data;

namespace dvteam_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;
	public UsuarioController (AppDbContext context)
	{
		_context = context;
	}
    
	[HttpGet("{id}")]
	public async Task<IActionResult> GetUsuario(int id)
	{
		if (id <= 0)
		{
			return BadRequest("ID inválido.");
		}

		var usuario = await _context.Usuarios.FindAsync(id);
		if (usuario == null)
		{
			return NotFound("Usuário não encontrado.");
		}

		return Ok(usuario);
	}

    [HttpPost]
	public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		_context.Usuarios.Add(usuario);
		await _context.SaveChangesAsync();
		return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
	}
}