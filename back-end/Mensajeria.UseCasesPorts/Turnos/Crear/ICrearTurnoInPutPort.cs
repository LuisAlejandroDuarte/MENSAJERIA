

using Mensajeria.DTOs.Turnos;

namespace Mensajeria.UseCasesPorts.Turnos.Crear
{
    public interface ICrearTurnoInPutPort
    {
        Task Handle(TurnoDTO turno);
    }
}
