using dvteam_api.Models;
using dvteam_api.Repositories;

namespace dvteam_api.Services;

public class UsuarioService : IUsuarioService
{
    // REGRAS DE NEGOCIO
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Usuario?> GetUsuarioAsync(int id)
    {
        return await _repository.GetUsuarioAsync(id);
    }

    public async Task<Usuario> CriarUsuarioAsync(Usuario usuario)
	{
		return await _repository.CriarUsuarioAsync(usuario);
	}
}