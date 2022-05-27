using Mensajeria.DTOs;
using Mensajeria.DTOs.Propietarios;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Propietarios.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class GetAllPropietariosController
    {
        readonly IGetAllPropietariosInPutPort InputPort;
        readonly IGetAllPropietarioOutPutPort OutputPort;

        readonly IGetPropietariosInPutPort InputPortPro;
        readonly IGetPropietariosOutPutPort OutputPortPro;

        readonly IHttpContextAccessor Context;

        public GetAllPropietariosController(IGetAllPropietariosInPutPort inputPort, IGetAllPropietarioOutPutPort outputPort, IGetPropietariosInPutPort inputPortPro, IGetPropietariosOutPutPort outputPortPro, IHttpContextAccessor context)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
            InputPortPro = inputPortPro;
            OutputPortPro = outputPortPro;
            Context = context;
        }

        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<ResultDataTable> GetAllPropietarios()
        {
            Paginator paginador;
            paginador = Paginator.GetPaginador(Context.HttpContext.Request.Form);

            await InputPort.Handle(paginador);
            return ((IPresenter<ResultDataTable>)OutputPort).Content;
        }

        [HttpGet("{empresaId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IEnumerable<PropietarioDTO>> GetAllPropietarios(long empresaId)
        {           
            await InputPortPro.Handle(empresaId);
            return ((IPresenter<IEnumerable<PropietarioDTO>>)OutputPortPro).Content;
        }
    }
}
