using Mensajeria.DTOs.Propietarios;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Propietarios.Editar;
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
    public class EditarPropietarioController
    {
        readonly IEditarPropietarioInPutPort inputPort;
        readonly IEditarPropietarioOutPutPort outputPort;

        public EditarPropietarioController(IEditarPropietarioInPutPort inputPort, IEditarPropietarioOutPutPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<PropietarioDTO> EditarPropietario(PropietarioDTO propietario)
        {
            await this.inputPort.Handle(propietario);
            return ((IPresenter<PropietarioDTO>)outputPort).Content;

        }

    }
}
