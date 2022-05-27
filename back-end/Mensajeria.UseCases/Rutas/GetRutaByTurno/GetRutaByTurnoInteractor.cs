using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Rutas.GetByTurno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Rutas.GetRutaByTurno
{
    public class GetRutaByTurnoInteractor : IGetRutaByTurnoInPutPort
    {

        readonly IRutaRepository repository;
        readonly IGetRutaByTurnoOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public GetRutaByTurnoInteractor(IRutaRepository repository, IGetRutaByTurnoOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(long turnoId)
        {
            var ruta = this.repository.GetRutaByTurno(turnoId);
            this.outPutPort.Handle(ruta);
            return Task.CompletedTask;
        }
    }
}
