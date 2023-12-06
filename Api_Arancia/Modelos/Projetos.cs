using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Modelos;

public class Projetos
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
}
