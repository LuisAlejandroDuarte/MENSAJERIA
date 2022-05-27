using Mensajeria.DTOs.Turnos;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Turnos.Editar;
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
    public class EditarTurnoController
    {
        readonly IEditarTurnoInPutPort inPutPort;
        readonly IEditarTurnoOutPutPort outPutPort;

        public EditarTurnoController(IEditarTurnoInPutPort inPutPort, IEditarTurnoOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpPut]
        [Authorize(Roles = "admin,user")]
        public async Task<TurnoDTO> EditarTurno(TurnoDTO turno)
        {
            await this.inPutPort.Handle(turno);
            return ((IPresenter<TurnoDTO>)this.outPutPort).Content;
        }
    }
}
