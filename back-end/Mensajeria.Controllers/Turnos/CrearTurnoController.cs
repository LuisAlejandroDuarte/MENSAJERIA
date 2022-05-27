using Mensajeria.DTOs.Turnos;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Turnos.Crear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Mensajeria.Controllers.Turnos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearTurnoController
    {
        readonly ICrearTurnoInPutPort inPutPort;
        readonly ICrearTurnoOutPutPort outPutPort;

        public CrearTurnoController(ICrearTurnoInPutPort inPutPort, ICrearTurnoOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<TurnoDTO> CrearTurno(TurnoDTO turno)
        {
            await this.inPutPort.Handle(turno);
            return ((IPresenter<TurnoDTO>)this.outPutPort).Content;
        }
    }
}
