using Mensajeria.DTOs.Motos;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Motos.Crear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Controllers.Motos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearMotoController
    {

        readonly ICrearMotoInPutPort inputPort;
        readonly ICrearMotoOutPutPort outputPort;

        public CrearMotoController(ICrearMotoInPutPort inputPort, ICrearMotoOutPutPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        [HttpPost]
        [Authorize(Roles = "admin,user")]

        public async Task<MotoDTO> CrearMoto(MotoDTO moto)
        {
          await  this.inputPort.Handle(moto);
          return ((IPresenter<MotoDTO>)this.outputPort).Content;
        }

    }
}
