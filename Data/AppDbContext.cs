using Microsoft.EntityFrameworkCore;
using dvteam_api.Models;

namespace dvteam_api.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<Tarefa> Tarefas { get; set; }
	public DbSet<Usuario> Usuarios { get; set; }
}