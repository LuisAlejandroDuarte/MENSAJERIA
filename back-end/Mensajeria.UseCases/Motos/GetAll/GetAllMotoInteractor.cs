using Mensajeria.DTOs;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Motos.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Motos.GetAll
{
    public class GetAllMotoInteractor : IGetAllMotoInPutPort
    {

        readonly IGetAllMotoOutPutPort outPutPort;
        readonly IMotoRepository repository;
        readonly IUnitOfWork unitOfWork;

        public GetAllMotoInteractor(IGetAllMotoOutPutPort outPutPort, IMotoRepository repository, IUnitOfWork unitOfWork)
        {
            this.outPutPort = outPutPort;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(Paginator paginador)
        {
            var motos =this.repository.GetAll(paginador);
            this.outPutPort.Handle(motos);
            return Task.CompletedTask;
        }
    }
}
