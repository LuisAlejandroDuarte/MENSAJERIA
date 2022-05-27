using Mensajeria.DTOs.Motos;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Motos.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Motos.Editar
{
    public class EditarMotoInteractor : IEditarMotoInPutPort
    {
        readonly IMotoRepository repository;
        readonly IEditarMotoOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public EditarMotoInteractor(IMotoRepository repository, IEditarMotoOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(MotoDTO moto)
        {
            this.repository.Actualizar(moto);
            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(moto);

        }
    }
}
