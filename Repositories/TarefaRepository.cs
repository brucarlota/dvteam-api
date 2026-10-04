using Microsoft.EntityFrameworkCore;
using dvteam_api.Data;
using dvteam_api.Models;
using dvteam_api.Repositories;

namespace dvteam_api.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _context;

    public TarefaRepository (AppDbContext context)
	{
		_context = context;
	}

    public async Task<List<Tarefa>> ListarTarefasAsync()
	{
		return await _context.Tarefas.ToListAsync();
	}

    public async Task<Tarefa?> GetTarefaAsync(int id)
    {
        return await _context.Tarefas.FindAsync(id);
    }

    public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
	{
		_context.Tarefas.Add(tarefa);
		await _context.SaveChangesAsync();
		return tarefa;
	}

    public async Task<Tarefa?> AtualizarTarefaAsync(int id, Tarefa tarefaAtualizada)
    {
		var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null) return null;

		tarefa.Titulo = tarefaAtualizada.Titulo;
		tarefa.Descricao = tarefaAtualizada.Descricao;
		tarefa.DataConclusao = tarefaAtualizada.DataConclusao;
		tarefa.Status = tarefaAtualizada.Status;

        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task<bool> DeletarTarefaAsync(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null) return false;

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return true;
    }
}