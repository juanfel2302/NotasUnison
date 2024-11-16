using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using notas_unison_core.modelos;

namespace notas_unison_core.BaseDeDatos;


public class NotasBD : DbContext 
{
    /// <summary>
    /// Nombre de la base de datos.
    /// </summary>
    private const string NombreBaseDeDatos = "datos.db";

    /// <summary>
    /// Tabla de notas.
    /// </summary>
    public DbSet<Notas> Notas { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Directorio donde se guarda la base de datos.
        var directorio = AppContext.BaseDirectory + "/_data";

        // 1. Asegurar que existe el directorio de la base de datos.
        if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

        // 2. Configuramos el nombre de la base de datos.
        optionsBuilder.UseSqlite(
            $"Filename={directorio}/{NombreBaseDeDatos}",
            op => op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
        
        // 3. Terminar con la configuración.
        base.OnConfiguring(optionsBuilder);
    }
    
    
    // Define la estructura de la base de datos.
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definir la tabla productos.
        modelBuilder.Entity<Notas>(notas =>
        {
            notas.ToTable(nameof(Notas));
            notas.HasKey(x => x.Id);
            notas.Property(x => x.titulo).IsRequired();
            notas.Property(x=> x.descripcion).IsRequired();
        });

    }
    
}