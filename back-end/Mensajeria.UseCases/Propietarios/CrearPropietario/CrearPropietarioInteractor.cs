using Mensajeria.DTOs.Propietarios;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Propietarios.Crear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Propietarios.CrearPropietario
{
    public class CrearPropietarioInteractor : ICrearPropietarioInPutPort
    {

        readonly IPropietarioRepository repository;
        readonly ICrearPropietarioOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public CrearPropietarioInteractor(IPropietarioRepository repository, ICrearPropietarioOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(PropietarioDTO propietario)
        {
            this.repository.Crear(propietario);
            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(propietario);            
        }
    }
}
