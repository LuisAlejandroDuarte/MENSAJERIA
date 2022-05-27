using Mensajeria.DTOs.Propietarios;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Propietarios.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Propietarios.Editar
{
    public class EditarPropietarioInteractor : IEditarPropietarioInPutPort
    {
        readonly IPropietarioRepository repository;
        readonly IEditarPropietarioOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public EditarPropietarioInteractor(IPropietarioRepository repository, IEditarPropietarioOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(PropietarioDTO propietario)
        {
            this.repository.Actualizar(propietario);
            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(propietario);
        }
    }
}
