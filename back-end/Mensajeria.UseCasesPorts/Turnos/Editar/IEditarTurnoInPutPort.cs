
using Mensajeria.DTOs.Turnos;

namespace Mensajeria.UseCasesPorts.Turnos.Editar
{
    public interface IEditarTurnoInPutPort
    {
        Task Handle(TurnoDTO turno);
    }
}
