using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Entities.POCOs
{
    public class Empresa
    {
        public long Id { get; set; }
        public string Nombre { get; set; }=string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public virtual ICollection<Usuario>? Usuarios { get; set; }

    }
}
