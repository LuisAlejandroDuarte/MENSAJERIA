using Mensajeria.DTOs.Turnos;

namespace Mensajeria.UseCasesPorts.Turnos.Crear
{
    public interface ICrearTurnoOutPutPort
    {
        Task Handle(TurnoDTO turno);
    }
}
