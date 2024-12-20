using Microsoft.EntityFrameworkCore;
using Net_Core_API_Store.Models;

namespace Net_Core_API_Store.Contexto
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Producto> Producto { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
