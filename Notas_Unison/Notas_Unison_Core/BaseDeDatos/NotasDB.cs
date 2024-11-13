using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Notas_Unison_Core.Models;

namespace Notas_Unison_Core.BaseDeDatos;

public class NotasDB : DbContext
{
    private const string NombreBaseDeDatos = "notas.db";
    public DbSet<Notas> Notas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var directorio = AppContext.BaseDirectory + "/_data";
        if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);
        optionsBuilder.UseSqlite(
            $"Filename={directorio}/{NombreBaseDeDatos}",
            op => op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
        base.OnConfiguring(optionsBuilder);
    } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notas>(nota =>
        {
            nota.ToTable(nameof(Notas));
            nota.HasKey(p => p.Id);
            nota.Property(p => p.Titulo).IsRequired();
            nota.Property(p => p.Descripcion).IsRequired();
        });

    }
}