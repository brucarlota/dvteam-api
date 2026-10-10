namespace dvteam_api.Services;

using dvteam_api.Models;

public interface IUsuarioService
{
    // CLASSE DA REGRA DE NEGOCIO
    Task<Usuario?> GetUsuarioAsync(int id);
    Task<Usuario> CriarUsuarioAsync(Usuario usuario);
}