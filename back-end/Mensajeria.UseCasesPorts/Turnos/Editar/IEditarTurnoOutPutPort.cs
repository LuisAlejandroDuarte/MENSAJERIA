

using Mensajeria.DTOs.Turnos;

namespace Mensajeria.UseCasesPorts.Turnos.Editar
{
    public interface IEditarTurnoOutPutPort
    {
        Task Handle(TurnoDTO turno);
    }
}
