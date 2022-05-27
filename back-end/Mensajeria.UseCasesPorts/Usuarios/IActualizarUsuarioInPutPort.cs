

using Mensajeria.DTOs.Usuarios;

namespace Mensajeria.UseCasesPorts.Usuarios
{
    public interface IActualizarUsuarioInPutPort
    {
        Task Handle(ActualizarUsuarioDTO usuario);
    }
}
