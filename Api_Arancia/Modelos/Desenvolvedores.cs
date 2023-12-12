using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Modelos;

public class Desenvolvedores
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }

    public virtual ICollection<Projetos> Projetos { get; set;}
}
