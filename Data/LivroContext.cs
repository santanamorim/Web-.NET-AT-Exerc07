using Microsoft.EntityFrameworkCore;
using Web_.NET_AT_Exerc07.Models;

namespace Web_.NET_AT_Exerc07.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
    }
}
