namespace dvteam_api.Repositories;

using dvteam_api.Models;

public interface IUsuarioRepository
{
    Task<Usuario?> GetUsuarioAsync(int id);
    Task<Usuario> CriarUsuarioAsync(Usuario usuario);
} 