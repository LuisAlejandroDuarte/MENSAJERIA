using Mensajeria.DTOs;

namespace Mensajeria.UseCasesPorts
{
    public interface ICrearUsuarioOutPutPort
    {
        Task Handle(UsuarioDTO usuario);
    }
}
