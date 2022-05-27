

namespace Mensajeria.UseCasesPorts.Turnos.GetAll
{
    public interface IObtenerTurnoEsperaInPutPort
    {
        Task Handle(long empresaId);
    }
}
