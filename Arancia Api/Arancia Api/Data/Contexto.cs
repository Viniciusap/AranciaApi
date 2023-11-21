using Microsoft.EntityFrameworkCore;

namespace Arancia_Api.Data
{
    public class ModelosContext : DbContext
    {
        public ModelosContext(DbContextOptions<ModelosContext>opts) : base(opts)
        {

        }

        public DbSet<ModelosContext> Empresa  { get; set; }
    }
}
