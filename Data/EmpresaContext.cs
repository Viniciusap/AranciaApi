using Arancia_Api.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Arancia_Api.Data;

public class EmpresaContext : DbContext
{
    public EmpresaContext(DbContextOptions<EmpresaContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Projeto>()
            .HasKey(projeto => new { projeto.EmpresaId });
        builder.Entity<Projeto>()
            .HasOne(projeto => projeto.Empresa)
            .WithMany(empresa => empresa.Projeto)
            .HasForeignKey(projeto => projeto.EmpresaId);
    }

    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<Projeto> Projeto { get; set; }
    public DbSet<Desenvolvedor> Desenvolvedor { get; set; }
}
