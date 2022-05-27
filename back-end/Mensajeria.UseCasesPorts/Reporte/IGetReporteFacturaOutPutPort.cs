

using Mensajeria.DTOs.Reporte;

namespace Mensajeria.UseCasesPorts.Reporte
{
    public interface IGetReporteFacturaOutPutPort
    {
        Task Handle(IEnumerable<RptFacturaDTO> rptFactura);
    }
}
