using Mensajeria.DTOs.Reporte;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Reporte;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Controllers.Reportes
{

    [Route("api/[controller]")]
    [ApiController]
    public class GetReporteFacturaController
    {
        readonly IGetReporteFacturaInPutPort inPutPort;
        readonly IGetReporteFacturaOutPutPort outPutPort;

        public GetReporteFacturaController(IGetReporteFacturaInPutPort inPutPort, IGetReporteFacturaOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpGet("{empresaId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IEnumerable<RptFacturaDTO>> GetReporteFactura(long empresaId)
        {
            await inPutPort.Handle(empresaId);
            return ((IPresenter<IEnumerable<RptFacturaDTO>>)outPutPort).Content;
        }
    }
}
