using Microsoft.AspNetCore.Mvc;
using dvteam_api.Models;
using dvteam_api.Services;
using dvteam_api.DTOs;

namespace dvteam_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    /// <summary>
    /// Busca um usuário pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do usuário.</param>
    /// <returns>Dados do usuário encontrado.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUsuario(int id)
    {
        if (id <= 0)
            return BadRequest(new
            {
                mensagem = "O ID informado é inválido."
            });

        var usuario = await _service.GetUsuarioAsync(id);

        if (usuario == null)
            return NotFound(new
            {
                mensagem = "Usuário não encontrado."
            });

        return Ok(new
        {
            usuario.Id,
            usuario.Nome,
            usuario.Email
        });
    }

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="request">Dados do usuário que será cadastrado.</param>
    /// <returns>Dados do usuário criado.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioRequest request)
    {
        var novoUsuario = await _service.CriarUsuarioAsync(request);

        return CreatedAtAction(
            nameof(GetUsuario),
            new { id = novoUsuario.Id },
            new
            {
                novoUsuario.Id,
                novoUsuario.Nome,
                novoUsuario.Email
            }
        );
    }
}