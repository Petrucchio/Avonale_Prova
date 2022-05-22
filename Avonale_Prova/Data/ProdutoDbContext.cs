using Avonale_Prova.Models;
using Microsoft.EntityFrameworkCore;

namespace Avonale_Prova.Data
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Comprar> Compras { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}
