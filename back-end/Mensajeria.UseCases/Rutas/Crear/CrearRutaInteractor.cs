using Mensajeria.DTOs.Rutas;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Rutas.Crear;

namespace Mensajeria.UseCases.Rutas.Crear
{
    public class CrearRutaInteractor : ICrearRutaInPutPort
    {
        readonly IRutaRepository repository;
        readonly ICrearRutaOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public CrearRutaInteractor(IRutaRepository repository, ICrearRutaOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(RutaDTO ruta)
        {
            var newRuta =this.repository.Crear(ruta);
            await this.unitOfWork.SaveChanges();
            await this.outPutPort.Handle(newRuta);                        
        }
    }
}
