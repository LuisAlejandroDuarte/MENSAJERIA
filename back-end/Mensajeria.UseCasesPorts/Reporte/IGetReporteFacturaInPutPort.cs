
namespace Mensajeria.UseCasesPorts.Reporte
{
    public interface IGetReporteFacturaInPutPort
    {
        Task Handle(long empresaId);
    }
}
