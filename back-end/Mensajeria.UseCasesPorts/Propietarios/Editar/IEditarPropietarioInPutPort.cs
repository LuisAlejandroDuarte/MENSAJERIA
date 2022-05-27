using Mensajeria.DTOs.Propietarios;
namespace Mensajeria.UseCasesPorts.Propietarios.Editar
{
    public interface IEditarPropietarioInPutPort
    {
        Task Handle(PropietarioDTO propietario);
    }
}
