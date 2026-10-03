namespace dvteam_api.Services;

using dvteam_api.Models;

public interface ITarefaService
{
    // CLASSE DA REGRA DE NEGOCIO
    Task<List<Tarefa>> ListarTarefasAsync();
    Task<Tarefa?> GetTarefaAsync(int id);
    Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);
	Task<Tarefa?> AtualizarTarefaAsync(int id, Tarefa tarefaAtualizada);
	Task<bool> DeletarTarefaAsync(int id);
}