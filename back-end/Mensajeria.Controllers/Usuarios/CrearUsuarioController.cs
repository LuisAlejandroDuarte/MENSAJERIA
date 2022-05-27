using Mensajeria.DTOs;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mensajeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearUsuarioController
    {
        readonly ICrearUsuarioInputPort InputPort;
        readonly ICrearUsuarioOutPutPort OutputPort;

        public CrearUsuarioController(ICrearUsuarioInputPort inputPort, ICrearUsuarioOutPutPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<UsuarioDTO> CrearUsuario(CrearUsuarioDTO usuario)
        {
            await InputPort.Handle(usuario);
            return ((IPresenter<UsuarioDTO>)OutputPort).Content;
        }
    }
}
