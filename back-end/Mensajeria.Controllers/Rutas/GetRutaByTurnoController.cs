using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mensajeria.UseCasesPorts.Rutas.Get;
using Mensajeria.Presenter;
using Mensajeria.DTOs.Rutas;
using Mensajeria.UseCasesPorts.Rutas.GetByTurno;

namespace Mensajeria.Controllers.Rutas
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetRutaByTurnoController
    {
        readonly IGetRutaByTurnoInPutPort inPutPort;
        readonly IGetRutaByTurnoOutPutPort outPutPort;

        public GetRutaByTurnoController(IGetRutaByTurnoInPutPort inPutPort, IGetRutaByTurnoOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpGet("{turnoId}")]
        [Authorize(Roles="admin,user")]
        public async Task<RutaDTO> GetRutaByTurno(long turnoId)
        {
            await this.inPutPort.Handle(turnoId);
            return ((IPresenter<RutaDTO>)outPutPort).Content;
        }
    }
}
