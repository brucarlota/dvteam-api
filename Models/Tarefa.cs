using System.ComponentModel.DataAnnotations;

namespace dvteam_api.Models;

public enum Status
{
	Pendente,
	EmAndamento,
	Concluida
}

public class Tarefa
{
	public int Id { get; set; }
	[Required(ErrorMessage = "O título é obrigatório.")]
	[MaxLength(100, ErrorMessage = "O título não pode ter mais de 100 caracteres.")]
	public required string Titulo { get; set; }
	[Required(ErrorMessage = "A descrição é obrigatória.")]
	[MaxLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
	public required string Descricao { get; set; }
	public DateTime DataCriacao { get; set; }
	public DateTime DataConclusao { get; set; }
	public Status Status { get; set; }
}