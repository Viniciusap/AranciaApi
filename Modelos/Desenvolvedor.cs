﻿using System.ComponentModel.DataAnnotations;

namespace Arancia_Api.Modelos;

public class Desenvolvedor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }

    public virtual ICollection<Projeto> Projeto { get; set; }

}
