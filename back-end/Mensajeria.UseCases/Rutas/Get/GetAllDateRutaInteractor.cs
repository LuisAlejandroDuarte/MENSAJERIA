using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Rutas.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Rutas.Get
{
    public class GetAllDateRutaInteractor : IGetAllDateInPutPort
    {

        readonly IGetAllDateOutPutPort outPutPort;
        readonly IRutaRepository repository;
        readonly IUnitOfWork unitOfWork;

        public GetAllDateRutaInteractor(IGetAllDateOutPutPort outPutPort, IRutaRepository repository, IUnitOfWork unitOfWork)
        {
            this.outPutPort = outPutPort;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public  Task Handle(long empresaId)
        {
            var rutas= this.repository.GetAllDate(empresaId);
            this.outPutPort.Handle(rutas);
            return Task.CompletedTask;

        }
    }
}
