using System.ComponentModel.DataAnnotations;

namespace Arancia_Api.Modelos
{
    public class Desenvolvedores
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
    }

}
