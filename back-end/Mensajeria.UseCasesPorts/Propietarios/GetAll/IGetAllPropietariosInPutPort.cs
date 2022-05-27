
using Mensajeria.DTOs;

namespace Mensajeria.UseCasesPorts.Propietarios.GetAll
{
    public interface  IGetAllPropietariosInPutPort
    {
        Task Handle(Paginator paginador);        
    }

    public interface IGetPropietariosInPutPort
    {
        Task Handle(long empresaId);
    }
}
