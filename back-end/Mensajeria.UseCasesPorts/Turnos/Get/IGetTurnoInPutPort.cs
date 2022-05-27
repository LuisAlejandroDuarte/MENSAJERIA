

namespace Mensajeria.UseCasesPorts.Turnos.Get
{
    public interface IGetTurnoInPutPort
    {
        Task Handle(long Id);
    }
}
