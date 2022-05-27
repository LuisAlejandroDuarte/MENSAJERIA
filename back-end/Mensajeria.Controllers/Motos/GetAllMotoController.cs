using Mensajeria.DTOs;
using Mensajeria.DTOs.Motos;
using Mensajeria.Presenter;
using Mensajeria.UseCasesPorts.Motos.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace Mensajeria.Controllers.Motos
{

    [Route("api/[controller]")]
    [ApiController]
    public class GetAllMotoController
    {

        readonly IGetAllMotoInPutPort inPutPort;
        readonly IGetAllMotoOutPutPort outPutPort;
        readonly IHttpContextAccessor Context;

        public GetAllMotoController(IGetAllMotoInPutPort inPutPort, IGetAllMotoOutPutPort outPutPort, IHttpContextAccessor context)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
            Context = context;
        }


        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<ResultDataTable> GetAll()
        {
            Paginator paginador;
            paginador = Paginator.GetPaginador(Context.HttpContext.Request.Form);

            await this.inPutPort.Handle(paginador);
            return ((IPresenter<ResultDataTable>)this.outPutPort).Content;

        }
    }
}
