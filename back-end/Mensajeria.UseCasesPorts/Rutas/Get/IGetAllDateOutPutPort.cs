using Mensajeria.DTOs.Rutas;

namespace Mensajeria.UseCasesPorts.Rutas.Get
{
    public interface IGetAllDateOutPutPort
    {
        Task Handle(IEnumerable<RutaDTO> rutas);
    }
}
