using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Turnos.MotosDispo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Turnos.MotoDispo
{
    public class GetMotoDisponibleInteractor:IMotoDisponibleInPutPort
    {
        readonly ITurnoRepository repository;
        readonly IMotoDisponibleOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public GetMotoDisponibleInteractor(ITurnoRepository repository, IMotoDisponibleOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(long empresaId)
        {
            var motos = this.repository.GetMotoDisponible(empresaId);
            this.outPutPort.Handle(motos);
            return Task.CompletedTask;
        }
    }
}
