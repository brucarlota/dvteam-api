using System.ComponentModel.DataAnnotations;

namespace dvteam_api.DTOs;

public class CriarUsuarioRequest
{
	[Required(ErrorMessage = "O nome é obrigatório.")]
	[MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
	public required string Nome { get; set; }

	[Required(ErrorMessage = "O email é obrigatório.")]
	[EmailAddress(ErrorMessage = "O email é inválido.")]
	public required string Email { get; set; }

	[Required(ErrorMessage = "A senha é obrigatória.")]
	[MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
	public required string Senha { get; set; }
}