using Api_Arancia.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Api_Arancia.Data;

public class EmpresaContext : DbContext
{
    public EmpresaContext(DbContextOptions<EmpresaContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Projetos>()
            .HasKey(Projeto => new { Projeto.EmpresaId, Projeto.DesenvolvedoresId });
        builder.Entity<Projetos>().HasOne(Projeto => Projeto.Empresa)
            .WithMany(Empresa => Empresa.Projetos)
            .HasForeignKey(Projetos => Projetos.EmpresaId);

        builder.Entity<Projetos>()
            .HasOne(Projeto => Projeto.Desenvolvedores)
            .WithMany(Desenvolvedores => Desenvolvedores.Projetos)
            .HasForeignKey(Projetos => Projetos.DesenvolvedoresId);

    }


    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<Projetos> Projetos { get; set; }
    public DbSet<Desenvolvedores> Desenvolvedores { get; set; }

}
