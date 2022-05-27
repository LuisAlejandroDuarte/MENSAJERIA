using Mensajeria.DTOs.Rutas;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Rutas.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Rutas.Editar
{
    public class EditarRutaInteractor : IEditarRutaInPutPort
    {

        readonly IRutaRepository repository;
        readonly IEditarRutaOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public EditarRutaInteractor(IRutaRepository repository, IEditarRutaOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(RutaDTO ruta)
        {
            var updateRuta = this.repository.Editar(ruta);
            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(updateRuta);
        }
    }
}
