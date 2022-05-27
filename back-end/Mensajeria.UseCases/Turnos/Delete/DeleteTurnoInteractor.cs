using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Turnos.Delete;

namespace Mensajeria.UseCases.Turnos.Delete
{
    public class DeleteTurnoInteractor : IDeleteTurnoInPutPort
    {

        readonly ITurnoRepository repository;
        readonly IDeleteTurnoOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public DeleteTurnoInteractor(ITurnoRepository repository, IDeleteTurnoOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(long Id)
        {
            var turno = this.repository.Delete(Id);
            await this.outPutPort.Handle(turno);
            await this.unitOfWork.SaveChanges();
        }
    }
}
