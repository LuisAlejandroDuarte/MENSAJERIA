using Mensajeria.DTOs;

namespace Mensajeria.UseCasesPorts.Usuarios
{
    public interface ILoginOutPutPort
    {
        Task Handle(UsuarioDTO usuario);
    }
}
