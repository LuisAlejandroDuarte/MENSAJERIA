

using Mensajeria.DTOs.Motos;
using Mensajeria.DTOs.Turnos;

namespace Mensajeria.Entities.Interfaces
{
    public interface ITurnoRepository
    {
        IEnumerable<TurnoDTO> ObtenerEnEspera(long empresaId);
        TurnoDTO Crear(TurnoDTO turno); 
        TurnoDTO Editar(TurnoDTO turno);
        TurnoDTO Get(long  Id);
        TurnoDTO Delete(long Id);
        IEnumerable<MotoDTO> GetMotoDisponible(long empresaId);

    }
}
