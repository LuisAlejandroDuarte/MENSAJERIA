
namespace Mensajeria.UseCasesPorts.Turnos.Delete
{
    public interface IDeleteTurnoInPutPort
    {
        Task Handle(long Id);
    }
}
