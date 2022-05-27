using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Motos.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Motos.Get
{
    public class GetMotoInteractor:IGetMotoInPutPort
    {
        readonly IMotoRepository repository;
        readonly IGetMotoOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public GetMotoInteractor(IMotoRepository repository, IGetMotoOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public  Task Handle(long Id)
        {
            var moto =this.repository.GetMoto(Id);
            this.outPutPort.Handle(moto);
            return Task.CompletedTask;

        }
    }
}
