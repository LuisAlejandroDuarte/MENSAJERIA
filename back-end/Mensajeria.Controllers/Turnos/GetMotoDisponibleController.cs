using Mensajeria.DTOs.Motos;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Turnos.MotosDispo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Controllers.Turnos
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMotoDisponibleController
    {
        readonly IMotoDisponibleOutPutPort outPutPort;
        readonly IMotoDisponibleInPutPort inPutPort;

        public GetMotoDisponibleController(IMotoDisponibleOutPutPort outPutPort, IMotoDisponibleInPutPort inPutPort)
        {
            this.outPutPort = outPutPort;
            this.inPutPort = inPutPort;
        }

        [HttpGet("{empresaId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IEnumerable<MotoDTO>> GetMotoDisponible(long empresaId)
        {
            await  this.inPutPort.Handle(empresaId);
            return ((IPresenter<IEnumerable<MotoDTO>>)this.outPutPort).Content;
        }
    }
}
