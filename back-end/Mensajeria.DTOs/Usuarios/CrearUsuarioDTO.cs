using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.DTOs
{
    public class CrearUsuarioDTO
    {
        public string User { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string Nombre { get; init; } = string.Empty;
        public string Apellido { get; init; } = string.Empty;
        public string Direccion { get; init; } = string.Empty;
        public string Telefono { get; init; } = string.Empty;
        public long EmpresaId { get; init; }
        public string Rol { get; init; } = string.Empty;
        public bool Estado { get; set; }
    }
}
