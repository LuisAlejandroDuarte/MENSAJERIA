using Mensajeria.DTOs.Rutas;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Rutas.Crear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Mensajeria.Controllers.Rutas
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearRutaController
    {
        readonly ICrearRutaInPutPort inPutPort;
        readonly ICrearRutaOutPutPort outPutPort;

        public CrearRutaController(ICrearRutaInPutPort inPutPort, ICrearRutaOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }


        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<RutaDTO> CrearRuta(RutaDTO ruta)
        {
            await this.inPutPort.Handle(ruta);
            return ((IPresenter<RutaDTO>)outPutPort).Content;
        }


    }
}
