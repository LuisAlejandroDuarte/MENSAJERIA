using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Turnos.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Turnos.Get
{
    public class ObtenerTurnoInteractor : IObtenerTurnoEsperaInPutPort
    {

        readonly ITurnoRepository repository;
        readonly IObtenerTurnoEsperaOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public ObtenerTurnoInteractor(ITurnoRepository repository, IObtenerTurnoEsperaOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(long empresaId)
        {
            var turnos = this.repository.ObtenerEnEspera(empresaId);
            this.outPutPort.Handle(turnos);
            return Task.CompletedTask;
        }
    }
}
