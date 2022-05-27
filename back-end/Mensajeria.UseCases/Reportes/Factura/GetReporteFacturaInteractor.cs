using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Reportes.Factura
{
    public class GetReporteFacturaInteractor : IGetReporteFacturaInPutPort
    {
        readonly IReporteRepository repository;
        readonly IGetReporteFacturaOutPutPort outPutPort;
        readonly IUnitOfWork unitOfWork;

        public GetReporteFacturaInteractor(IReporteRepository repository, IGetReporteFacturaOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(long empresaId)
        {
            var listFacturas = this.repository.GetReporteFactura(empresaId);
            this.outPutPort.Handle(listFacturas);
            return Task.CompletedTask;

        }
    }
}
