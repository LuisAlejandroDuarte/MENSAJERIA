using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Entities.POCOs
{
    public class Usuario
    {
        public long Id { get; set; }
        public string User { get; set; } = string.Empty;

        
        public string Password { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;        
        public long EmpresaId { get; set; }
        public bool Estado { get; set; }
        public string Rol { get; set; }=string.Empty;
        public virtual Empresa? Empresa { get; set; }

    }
}
