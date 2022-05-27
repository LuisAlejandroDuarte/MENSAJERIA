using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Entities.POCOs
{
    public class Turno
    {
        public long Id { get; set; }
        public long MotoId { get; set; }
        public int Posicion { get; set; }
        public DateTime FechaHora { get; set; }        
        public int? Estado { get; set; }

        public virtual Moto? Moto { get; set; }

    }
}
