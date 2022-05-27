using Mensajeria.DTOs.Propietarios;

namespace Mensajeria.UseCasesPorts.Propietarios.Get
{
    public interface IGetPropietarioOutPutPort
    {
        Task Handle(PropietarioDTO propietario);
    }
}
