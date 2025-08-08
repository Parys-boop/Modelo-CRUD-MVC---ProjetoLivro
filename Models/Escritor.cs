using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivroCadastro.Models
{
    public class Escritor
    {
        public int EscritorId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        // Inicializa a lista para evitar null reference
        public List<Livro> Livros { get; set; } = new List<Livro>();
    }
}
