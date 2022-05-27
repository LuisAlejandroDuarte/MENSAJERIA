using Mensajeria.DTOs;


namespace Mensajeria.UseCasesPorts
{
    public interface ICrearUsuarioInputPort
    {
        Task Handle(CrearUsuarioDTO usuario);
    }
}
