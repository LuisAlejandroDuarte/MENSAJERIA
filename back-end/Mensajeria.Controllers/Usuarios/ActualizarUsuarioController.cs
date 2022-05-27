using Mensajeria.DTOs.Usuarios;
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
    public class ActualizarUsuarioController
    {
        readonly IActualizarUsuarioInPutPort InputPort;
        readonly IActualizarUsuarioOutPutPort OutputPort;

        public ActualizarUsuarioController(IActualizarUsuarioInPutPort inputPort, IActualizarUsuarioOutPutPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpPut]
        [Authorize(Roles = "admin")]

        public async Task<bool> ActualizarUsuario(ActualizarUsuarioDTO usuario)
        {
            await InputPort.Handle(usuario);
            return ((IPresenter<bool>)OutputPort).Content;
        }
    }
}
