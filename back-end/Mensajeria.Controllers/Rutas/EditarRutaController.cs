using Mensajeria.DTOs.Rutas;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Rutas.Editar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Controllers.Rutas
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditarRutaController
    {
        readonly IEditarRutaInPutPort inPutPort;
        readonly IEditarRutaOutPutPort outPutPort;

        public EditarRutaController(IEditarRutaInPutPort inPutPort, IEditarRutaOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpPut]
        [Authorize(Roles = "admin,user")]
        public async Task<RutaDTO> EditarRuta(RutaDTO ruta)
        {
            await this.inPutPort.Handle(ruta);
            return ((IPresenter<RutaDTO>)outPutPort).Content;
        }
    }
}
