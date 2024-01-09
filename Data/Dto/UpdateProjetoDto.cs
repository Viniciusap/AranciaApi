using System.ComponentModel.DataAnnotations;

namespace Arancia_Api.Data.Dto;

public class UpdateProjetoDto
{
    [Required]
    public string Nome { get; set; }
}
