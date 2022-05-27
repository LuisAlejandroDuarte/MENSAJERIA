using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mensajeria.UseCasesPorts.Turnos.Delete;
using Mensajeria.UseCases.Turnos.Delete;
using Mensajeria.DTOs.Turnos;
using Mensajeria.Presenter;

namespace Mensajeria.Controllers.Turnos
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteTurnoController
    {

        readonly IDeleteTurnoInPutPort inPutPort;
        readonly IDeleteTurnoOutPutPort outPutPort;

        public DeleteTurnoController(IDeleteTurnoInPutPort inPutPort, IDeleteTurnoOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<TurnoDTO> DeleteTurno(long Id)
        {
            await this.inPutPort.Handle(Id);
            return ((IPresenter<TurnoDTO>)this.outPutPort).Content;

        }

    }
}
