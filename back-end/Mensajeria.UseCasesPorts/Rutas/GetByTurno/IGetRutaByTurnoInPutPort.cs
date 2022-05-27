

namespace Mensajeria.UseCasesPorts.Rutas.GetByTurno
{
    public interface IGetRutaByTurnoInPutPort
    {
        Task Handle(long turnoId);
    }
}
