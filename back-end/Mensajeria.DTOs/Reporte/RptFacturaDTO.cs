using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.DTOs.Reporte
{
    public class RptFacturaDTO
    {
        public long PropietarioId { get; set; }
        public string NombrePropietario { get; set; }=string.Empty;
        public DateTime? Inicia { get; set; }
        public DateTime? Termina { get; set; }
        public string Placa { get; set; } = string.Empty;
        public decimal Valor { get; set; }

    }
}
