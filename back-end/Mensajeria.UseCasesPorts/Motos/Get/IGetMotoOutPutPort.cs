using Mensajeria.DTOs.Motos;
namespace Mensajeria.UseCasesPorts.Motos.Get
{
    public interface IGetMotoOutPutPort
    {
        Task Handle(MotoDTO moto); 
    }
}
