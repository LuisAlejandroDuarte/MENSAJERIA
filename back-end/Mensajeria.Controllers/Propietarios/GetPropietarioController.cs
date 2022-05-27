using Mensajeria.DTOs.Propietarios;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Propietarios.Get;
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
    public class GetPropietarioController
    {
        readonly IGetPropietarioInPutPort inputPort;
        readonly IGetPropietarioOutPutPort outputPort;

        public GetPropietarioController(IGetPropietarioInPutPort inputPort, IGetPropietarioOutPutPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<PropietarioDTO> GetPropietario(long Id)
        {
            await inputPort.Handle(Id);
            return ((IPresenter<PropietarioDTO>)outputPort).Content;
        }

    }
}
