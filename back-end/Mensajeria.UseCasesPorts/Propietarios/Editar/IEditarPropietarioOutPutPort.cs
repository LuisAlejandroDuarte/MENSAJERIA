using Mensajeria.DTOs.Propietarios;

namespace Mensajeria.UseCasesPorts.Propietarios.Editar
{
    public interface IEditarPropietarioOutPutPort
    {
        Task Handle(PropietarioDTO propietario);
    }
}
