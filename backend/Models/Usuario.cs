using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace dvteam_api.Models;

public class Usuario
{
	public int Id { get; set; }
	[Required(ErrorMessage = "O nome é obrigatório.")]
	[MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
	public required string Nome { get; set; }
	[Required(ErrorMessage = "O email é obrigatório.")]
	[EmailAddress(ErrorMessage = "O email é inválido.")]
	public required string Email { get; set; }
	[Required]
	[Column("Senha")]
	[JsonIgnore]
	public required string SenhaHash { get; set; }
}