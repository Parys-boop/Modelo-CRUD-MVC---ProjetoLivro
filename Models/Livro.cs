using System.ComponentModel.DataAnnotations;

namespace LivroCadastro.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; }

        [Display(Name = "Escritor")]

        [Range(1, int.MaxValue, ErrorMessage = "Você precisa selecionar um escritor.")]
        public int EscritorId { get; set; }

        public Escritor Escritor { get; set; }
    }
}
