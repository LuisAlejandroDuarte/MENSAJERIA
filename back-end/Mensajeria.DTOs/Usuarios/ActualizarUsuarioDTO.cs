using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.DTOs.Usuarios
{
    public class ActualizarUsuarioDTO
    {
        public long Id { get; set; }        
        public string User { get; init; } = string.Empty;        
        public string Nombre { get; init; } = string.Empty;
        public string Apellido { get; init; } = string.Empty;
        public string Direccion { get; init; } = string.Empty;
        public string Telefono { get; init; } = string.Empty;        
        public string Rol { get; init; } = string.Empty;
        public long EmpresaId { get; set; }
        public bool Estado { get; set; }
    }
}
