using Mensajeria.DTOs.Turnos;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Turnos.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Controllers.Turnos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObtenerTurnosEsperaController
    {
        readonly IObtenerTurnoEsperaInPutPort inPutPort;
        readonly IObtenerTurnoEsperaOutPutPort outPutPort;

        public ObtenerTurnosEsperaController(IObtenerTurnoEsperaInPutPort inPutPort, IObtenerTurnoEsperaOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpGet("{EmpresaId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IEnumerable<TurnoDTO>> ObtenerTurnosEspera(long EmpresaId)
        {
            await this.inPutPort.Handle(EmpresaId);
            return ((IPresenter<IEnumerable<TurnoDTO>>)this.outPutPort).Content;
        }


    }
}
