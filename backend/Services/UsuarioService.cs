using dvteam_api.Models;
using dvteam_api.Repositories;
using dvteam_api.DTOs;
using Microsoft.AspNetCore.Identity;

namespace dvteam_api.Services;

public class UsuarioService : IUsuarioService
{
    // REGRAS DE NEGOCIO
    private readonly IUsuarioRepository _repository;
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public UsuarioService(
        IUsuarioRepository repository,
        IPasswordHasher<Usuario> passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Usuario?> GetUsuarioAsync(int id)
    {
        return await _repository.GetUsuarioAsync(id);
    }

    public async Task<Usuario> CriarUsuarioAsync(CriarUsuarioRequest request)
	{
        var usuario = new Usuario
        {
            Nome = request.Nome,
            Email = request.Email,
            SenhaHash = string.Empty
        };
        usuario.SenhaHash = _passwordHasher.HashPassword(usuario, request.Senha);

		return await _repository.CriarUsuarioAsync(usuario);
	}
}