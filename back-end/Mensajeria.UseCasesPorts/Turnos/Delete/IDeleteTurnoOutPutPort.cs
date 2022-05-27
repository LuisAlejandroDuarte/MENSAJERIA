using Mensajeria.DTOs.Turnos;

namespace Mensajeria.UseCases.Turnos.Delete
{
    public interface IDeleteTurnoOutPutPort
    {
        Task Handle(TurnoDTO turno);
    }
}
