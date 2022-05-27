using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Entities.POCOs
{
    public class Moto
    {
        public long Id { get; set; }        
        public long PropietarioId { get; set; }
        public string Placa { get; set; } =string.Empty;
        public bool? Estado { get; set; }

        public virtual Propietario? Propietario { get; set; }

    }
}
