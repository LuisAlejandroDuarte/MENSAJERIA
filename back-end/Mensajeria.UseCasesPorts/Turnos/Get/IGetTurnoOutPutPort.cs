using Mensajeria.DTOs.Turnos;
namespace Mensajeria.UseCasesPorts.Turnos.Get
{
    public interface IGetTurnoOutPutPort
    {
        Task Handle(TurnoDTO turno);
    }
}
