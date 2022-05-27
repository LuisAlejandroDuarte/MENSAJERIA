using Mensajeria.DTOs.Usuarios;

namespace Mensajeria.UseCasesPorts.Usuarios
{
    public interface ILoginInputPort
    {
        Task Handle(LoginDTO login);
    }
}
