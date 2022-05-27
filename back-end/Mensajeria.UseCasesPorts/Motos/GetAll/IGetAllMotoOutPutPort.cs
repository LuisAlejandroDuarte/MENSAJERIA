
using Mensajeria.DTOs;
using Mensajeria.DTOs.Motos;

namespace Mensajeria.UseCasesPorts.Motos.GetAll
{
    public interface IGetAllMotoOutPutPort
    {
        Task Handle(ResultDataTable motos);
    }
}
