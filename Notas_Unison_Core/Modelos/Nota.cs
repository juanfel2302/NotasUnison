using System;

namespace Notas_Unison_Core.Modelos;

public class Nota
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Contenido { get; set; } = string.Empty;
    public string Colorin { get; set; } = string.Empty;
}