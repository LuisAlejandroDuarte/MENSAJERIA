using Mensajeria.DTOs;

namespace Mensajeria.UseCasesPorts
{
    public interface IGetAllUsuariosOutputPort
    {
        Task Handle(IEnumerable<UsuarioDTO> usuarios);
    }


    public interface IGetUsuariosOutPutPort
    {
        Task Handle(ResultDataTable result);
    }
}
