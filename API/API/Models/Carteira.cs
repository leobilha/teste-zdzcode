using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Carteira
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo matrícula é obrigatório.")]
        public string Matricula { get; set; }

        [Required]
        public string ImagemCarteira { get; set; }
    }
}
