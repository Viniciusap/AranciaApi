using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Data.Dtos;

public class CreateProjetosDto
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }
}
