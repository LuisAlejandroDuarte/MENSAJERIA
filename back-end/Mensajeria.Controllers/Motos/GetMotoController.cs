using Mensajeria.DTOs.Motos;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Motos.Get;
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
    public class GetMotoController
    {
        readonly IGetMotoInPutPort inPutPort;
        readonly IGetMotoOutPutPort outPutPort;

        public GetMotoController(IGetMotoInPutPort inPutPort, IGetMotoOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<MotoDTO> Get(long Id)
        {
            await this.inPutPort.Handle(Id);
            return ((IPresenter<MotoDTO>)this.outPutPort).Content;
        }
    }
}
