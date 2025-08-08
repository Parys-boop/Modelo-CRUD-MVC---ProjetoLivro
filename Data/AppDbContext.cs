using LivroCadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroCadastro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Escritor> Escritores { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
