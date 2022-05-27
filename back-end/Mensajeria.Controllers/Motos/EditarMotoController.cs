using Mensajeria.DTOs.Motos;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Motos.Editar;
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
    public class EditarMotoController
    {
        readonly IEditarMotoInPutPort inPutPort;
        readonly IEditarMotoOutPutPort outPutPort;

        public EditarMotoController(IEditarMotoInPutPort inPutPort, IEditarMotoOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }


        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<MotoDTO> EditarMoto(MotoDTO moto)
        {
            await this.inPutPort.Handle(moto);
            return ((IPresenter<MotoDTO>)this.outPutPort).Content;
        }

    }
}
