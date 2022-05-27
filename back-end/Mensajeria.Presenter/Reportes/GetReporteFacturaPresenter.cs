using Mensajeria.DTOs.Reporte;
using Mensajeria.UseCasesPorts.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Reportes
{
    public class GetReporteFacturaPresenter : IGetReporteFacturaOutPutPort, IPresenter<IEnumerable<RptFacturaDTO>>
    {
        public IEnumerable<RptFacturaDTO> Content {get;private set;}

        public Task Handle(IEnumerable<RptFacturaDTO> rptFactura)
        {
            Content = rptFactura;
           return Task.CompletedTask;
        }
    }
}
