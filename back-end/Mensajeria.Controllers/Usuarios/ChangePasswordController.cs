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
    public class ChangePasswordController
    {
        readonly IChangePasswordInPutPort inputPort;
        readonly IChangePasswordOutPutPort outputPort;

        public ChangePasswordController(IChangePasswordInPutPort inputPort, IChangePasswordOutPutPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<bool> ChangePassword(UsuarioDTO usuario)
        {
            await this.inputPort.Handle(usuario);
            return ((IPresenter<bool>)outputPort).Content;
        }

    }
}
