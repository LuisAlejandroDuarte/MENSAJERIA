using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.DTOs.Motos
{
    public class MotoDTO:ColumnsAccion
    {
        public long Id { get; set; }
        public long PropietarioId { get; set; }
        public string NombrePropietario { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public bool? Estado { get; set; }

    }
}
