﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Unison_Almacen_Core.Modelos;

namespace Unison_Almacen_Core.BaseDeDatos;

// ReSharper disable once InconsistentNaming
public class NotasDB : DbContext
{
    /// <summary>
    /// Nombre de la base de datos.
    /// </summary>
    private const string NombreBaseDeDatos = "datos.db";

    /// <summary>
    /// Tabla de productos.
    /// </summary>
    public DbSet<Notas> Notas { get; set; }

    /// <summary>
    /// Configura la dirección de la base de datos.
    /// </summary>
    /// <param name="optionsBuilder"></param>
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

    /// <summary>
    /// Define la estructura de la base de datos.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definir la tabla productos.
        modelBuilder.Entity<Notas>(notas =>
        {
            notas.ToTable(nameof(Notas));
            notas.HasKey(p => p.Id);
            notas.Property(p => p.Titulo).IsRequired();
            notas.Property(p => p.Descripcion).IsRequired();
        });

    }
}