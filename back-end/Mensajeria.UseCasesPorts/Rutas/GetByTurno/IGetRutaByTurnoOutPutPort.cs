using Mensajeria.DTOs.Rutas;

namespace Mensajeria.UseCasesPorts.Rutas.GetByTurno
{
    public interface IGetRutaByTurnoOutPutPort
    {
        Task Handle(RutaDTO ruta);
    }
}
