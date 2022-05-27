using Mensajeria.DTOs.Turnos;

namespace Mensajeria.UseCasesPorts.Turnos.GetAll
{
    public interface IObtenerTurnoEsperaOutPutPort
    {
        Task Handle(IEnumerable<TurnoDTO> turnos);
    }
}
