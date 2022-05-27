using Mensajeria.DTOs;
using Mensajeria.DTOs.Usuarios;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Usuarios;
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
    public class LoginController
    {
        readonly ILoginInputPort InputPort;
        readonly ILoginOutPutPort OutputPort;

        public LoginController(ILoginInputPort inputPort, ILoginOutPutPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpPost]
        public async Task<UsuarioDTO> Login(LoginDTO login)
        {
            await InputPort.Handle(login);
            return ((IPresenter<UsuarioDTO>)OutputPort).Content;
        }
    }
}
