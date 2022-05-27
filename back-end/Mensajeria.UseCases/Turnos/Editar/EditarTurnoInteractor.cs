using Mensajeria.DTOs.Turnos;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Turnos.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Turnos.Editar
{
    public class EditarTurnoInteractor : IEditarTurnoInPutPort
    {

        readonly ITurnoRepository repository;
        readonly IEditarTurnoOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public EditarTurnoInteractor(ITurnoRepository repository, IEditarTurnoOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(TurnoDTO turno)
        {
            var turnoeditado = this.repository.Editar(turno);
            await this.outPutPort.Handle(turnoeditado);
            await this.unitOfWork.SaveChanges();            
            
        }
    }
}
