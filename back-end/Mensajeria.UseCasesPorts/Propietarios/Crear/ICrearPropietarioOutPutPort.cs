using Mensajeria.DTOs.Propietarios;

namespace Mensajeria.UseCasesPorts.Propietarios.Crear
{
    public interface ICrearPropietarioOutPutPort
    {
        Task Handle(PropietarioDTO propietario);
    }
}
