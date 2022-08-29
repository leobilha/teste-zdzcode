using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    public class ReadEstudanteDto
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo matrícula é obrigatório.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O campo curso é obrigatório.")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "O campo instituição é obrigatório.")]
        public string Instituicao { get; set; }

        [Required(ErrorMessage = "A foto é obrigatória.")]
        public string Foto { get; set; }

        public string ImagemCarteira { get; set; }

    }
}
