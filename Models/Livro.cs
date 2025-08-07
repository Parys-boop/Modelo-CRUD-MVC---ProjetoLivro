using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivroCadastro.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Display(Name = "Escritor")]
        public int EscritorId { get; set; }

        public Escritor Escritor { get; set; }
    }
}
