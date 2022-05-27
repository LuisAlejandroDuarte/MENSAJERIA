using Mensajeria.DTOs;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenewTokenController
    {
        readonly IRenewTokenInPutPort InputPort;
        readonly IRenewTokenOutPutPort OutputPort;

        public RenewTokenController(IRenewTokenInPutPort inputPort, IRenewTokenOutPutPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpGet("ReNewToken")]     
        public async Task<UsuarioDTO> RenewToken([FromHeader(Name = "x-token")] string token)
        {
            await InputPort.Handle(token);
            return ((IPresenter<UsuarioDTO>)OutputPort).Content;
           
        }
    }
}
