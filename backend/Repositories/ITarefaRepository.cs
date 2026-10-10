namespace dvteam_api.Repositories;

using dvteam_api.Models;

public interface ITarefaRepository
{
    Task<List<Tarefa>> ListarTarefasAsync();
    Task<Tarefa?> GetTarefaAsync(int id);
    Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);
	Task<Tarefa?> AtualizarTarefaAsync(int id, Tarefa tarefaAtualizada);
	Task<bool> DeletarTarefaAsync(int id);
} 