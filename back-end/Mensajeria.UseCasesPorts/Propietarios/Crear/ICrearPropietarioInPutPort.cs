using Mensajeria.DTOs.Propietarios;


namespace Mensajeria.UseCasesPorts.Propietarios.Crear
{
    public interface ICrearPropietarioInPutPort
    {
        Task Handle(PropietarioDTO propietario);
    }
}
