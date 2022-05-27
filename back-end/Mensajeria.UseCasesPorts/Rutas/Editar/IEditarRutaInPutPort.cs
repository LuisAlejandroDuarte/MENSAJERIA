using Mensajeria.DTOs.Rutas;


namespace Mensajeria.UseCasesPorts.Rutas.Editar
{
    public interface IEditarRutaInPutPort
    {
        Task Handle(RutaDTO ruta);
    }
}
