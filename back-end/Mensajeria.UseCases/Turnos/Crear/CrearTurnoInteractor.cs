using Mensajeria.DTOs.Turnos;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Turnos.Crear;

namespace Mensajeria.UseCases.Turnos.Crear
{
    public class CrearTurnoInteractor : ICrearTurnoInPutPort
    {
        readonly ICrearTurnoOutPutPort outPutPort;
        readonly ITurnoRepository repository;
        readonly IUnitOfWork unitOfWork;

        public CrearTurnoInteractor(ICrearTurnoOutPutPort outPutPort, ITurnoRepository repository, IUnitOfWork unitOfWork)
        {
            this.outPutPort = outPutPort;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(TurnoDTO turno)
        {
           var newTurno= this.repository.Crear(turno);
            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(newTurno);
          
        }
    }
}
