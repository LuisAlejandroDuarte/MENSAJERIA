using Mensajeria.DTOs.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Entities.Interfaces
{
    public interface IReporteRepository
    {
        IEnumerable<RptFacturaDTO> GetReporteFactura(long empresaId);
    }
}
