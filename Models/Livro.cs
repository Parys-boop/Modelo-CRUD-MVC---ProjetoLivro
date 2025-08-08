using System.ComponentModel.DataAnnotations;

namespace LivroCadastro.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; }

        [Display(Name = "Escritor")]
        public int EscritorId { get; set; }

        public Escritor Escritor { get; set; }
    }
}
