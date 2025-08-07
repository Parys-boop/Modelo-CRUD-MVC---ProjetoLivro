using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjetoLivro.Models;

namespace LivroCadastro.Models
{
    public class Escritor
    {
        public int EscritorId { get; set; }

        [Required]
        public string Nome { get; set; }

        public List<Livro> Livros { get; set; }
    }
}
