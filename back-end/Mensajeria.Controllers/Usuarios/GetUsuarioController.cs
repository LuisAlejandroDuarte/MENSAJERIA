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
    public class GetUsuarioController
    {
        readonly IGetUsuarioInPutPort InputPort;
        readonly IGetUsuarioOutPutPort OutputPort;

        public GetUsuarioController(IGetUsuarioInPutPort inputPort, IGetUsuarioOutPutPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<UsuarioDTO> GetUsuario(long Id)
        {
            await InputPort.Handle(Id);
            return ((IPresenter<UsuarioDTO>)OutputPort).Content;
        }
    }
}
