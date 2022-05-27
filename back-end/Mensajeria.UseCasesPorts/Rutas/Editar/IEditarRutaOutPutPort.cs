using Mensajeria.DTOs.Rutas;

namespace Mensajeria.UseCasesPorts.Rutas.Editar
{
    public interface IEditarRutaOutPutPort
    {
        Task Handle(RutaDTO ruta);
    }
}
