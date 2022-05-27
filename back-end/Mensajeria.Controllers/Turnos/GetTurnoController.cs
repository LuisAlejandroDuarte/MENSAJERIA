using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mensajeria.UseCasesPorts.Turnos.Get;
using Mensajeria.DTOs.Turnos;
using Mensajeria.Presenter;

namespace Mensajeria.Controllers.Turnos
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTurnoController
    {
        readonly IGetTurnoInPutPort inPutPort;
        readonly IGetTurnoOutPutPort outPutPort;

        public GetTurnoController(IGetTurnoInPutPort inPutPort, IGetTurnoOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpGet("{Id}")]
        [Authorize(Roles ="admin,user")]
        public async Task<TurnoDTO> GetTurno(long Id)
        {
            await this.inPutPort.Handle(Id);
            return ((IPresenter<TurnoDTO>)this.outPutPort).Content;
        }

    }
}
