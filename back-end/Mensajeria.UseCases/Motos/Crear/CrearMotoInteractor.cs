using Mensajeria.DTOs.Motos;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Motos.Crear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Motos.Crear
{
    public class CrearMotoInteractor : ICrearMotoInPutPort
    {

        readonly IMotoRepository repository;
        readonly ICrearMotoOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public CrearMotoInteractor(IMotoRepository repository, ICrearMotoOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(MotoDTO moto)
        {
            this.repository.Crear(moto);
            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(moto);           
        }
    }
}
