using Mensajeria.DTOs;

namespace Mensajeria.UseCasesPorts.Motos.GetAll
{
    public interface IGetAllMotoInPutPort
    {
        Task Handle(Paginator paginador);
    }
}
