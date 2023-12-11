using Api_Arancia.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Api_Arancia.Data;

public class EmpresaContext : DbContext
{
    public EmpresaContext(DbContextOptions<EmpresaContext> opts) : base(opts)
    {

    }

    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<Projetos> Projetos { get; set; }
    public DbSet<Desenvolvedores> Desenvolvedores { get; set; }

}
