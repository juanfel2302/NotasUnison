using notas_unison_core.Contratos.Servicios;
using notas_unison_core.modelos;
using unison_notas_core.Contratos.Repositorios;


namespace notas_unison_core.Contratos.Servicios;

public class NotasServicio(IRepositorio<Notas> repositorio) : IServicio<Notas>
{
    
}