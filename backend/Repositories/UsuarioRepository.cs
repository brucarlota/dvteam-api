using Microsoft.EntityFrameworkCore;
using dvteam_api.Data;
using dvteam_api.Models;
using dvteam_api.Repositories;

namespace dvteam_api.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository (AppDbContext context)
	{
		_context = context;
	}

	public async Task<Usuario?> GetUsuarioAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

	public async Task<Usuario> CriarUsuarioAsync(Usuario usuario)
	{
		_context.Usuarios.Add(usuario);
		await _context.SaveChangesAsync();
		return usuario;
	}
}