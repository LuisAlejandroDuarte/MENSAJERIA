using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mensajeria.UseCasesPorts.Rutas.Get;
using Mensajeria.Presenter;
using Mensajeria.DTOs.Rutas;

namespace Mensajeria.Controllers.Rutas
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllDateRutaController
    {
        readonly IGetAllDateInPutPort inPutPort;
        readonly IGetAllDateOutPutPort outPutPort;

        public GetAllDateRutaController(IGetAllDateInPutPort inPutPort, IGetAllDateOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }


        [HttpGet("{empresaId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IEnumerable<RutaDTO>> GetAllDateRuta(long empresaId)
        {
            await this.inPutPort.Handle(empresaId);
            return ((IPresenter<IEnumerable<RutaDTO>>)outPutPort).Content;
        }
    }
}
