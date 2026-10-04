using dvteam_api.Models;
using dvteam_api.Repositories;

namespace dvteam_api.Services;

public class TarefaService : ITarefaService
{
    // REGRAS DE NEGOCIO
    private readonly ITarefaRepository _repository;

    public TarefaService(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Tarefa>> ListarTarefasAsync()
	{
		return await _repository.ListarTarefasAsync();
	}

    public async Task<Tarefa?> GetTarefaAsync(int id)
    {
        return await _repository.GetTarefaAsync(id);
    }

    public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
	{
		return await _repository.CriarTarefaAsync(tarefa);
	}

    public async Task<Tarefa?> AtualizarTarefaAsync(int id, Tarefa tarefaAtualizada)
    {
        return await _repository.AtualizarTarefaAsync(id, tarefaAtualizada);
    }

    public async Task<bool> DeletarTarefaAsync(int id)
    {
        return await _repository.DeletarTarefaAsync(id);
    }
}