using Mensajeria.DTOs.Propietarios;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Propietarios.Crear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Controllers.Propietarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearPropietarioController
    {
        readonly ICrearPropietarioInPutPort inputPort;
        readonly ICrearPropietarioOutPutPort outputPort;

        public CrearPropietarioController(ICrearPropietarioInPutPort inputPort, ICrearPropietarioOutPutPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<PropietarioDTO> CrearPropietario(PropietarioDTO propietario)
        {
            await this.inputPort.Handle(propietario);
            return ((IPresenter<PropietarioDTO>)outputPort).Content;
        }

    }
}
