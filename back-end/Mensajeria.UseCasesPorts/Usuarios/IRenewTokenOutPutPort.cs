

using Mensajeria.DTOs;

namespace Mensajeria.UseCasesPorts.Usuarios
{
    public interface IRenewTokenOutPutPort
    {
        Task Handle(UsuarioDTO usuario);
    }
}
