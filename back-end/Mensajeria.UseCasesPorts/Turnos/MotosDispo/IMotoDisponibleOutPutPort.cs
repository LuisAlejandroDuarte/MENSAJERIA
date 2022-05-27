using Mensajeria.DTOs.Motos;


namespace Mensajeria.UseCasesPorts.Turnos.MotosDispo
{
    public interface IMotoDisponibleOutPutPort
    {
        Task Handle(IEnumerable<MotoDTO> motos);
    }
}
