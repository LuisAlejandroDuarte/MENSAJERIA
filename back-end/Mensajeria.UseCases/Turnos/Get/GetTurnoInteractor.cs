using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Turnos.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Turnos.Get
{
    public class GetTurnoInteractor:IGetTurnoInPutPort
    {
        readonly ITurnoRepository repository;
        readonly IGetTurnoOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public GetTurnoInteractor(ITurnoRepository repository, IGetTurnoOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(long Id)
        {
            var turno = this.repository.Get(Id);
            this.outPutPort.Handle(turno);
            return Task.CompletedTask;
        }
    }
}
