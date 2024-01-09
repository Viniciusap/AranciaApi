using System.ComponentModel.DataAnnotations;

namespace Arancia_Api.Data.Dto;

public class UpdateDesenvolvedorDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }
}
