using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.DTOs
{
    public class UsuarioDTO:ColumnsAccion
    {
        public long Id { get; init; }
        public string User { get; init; } = string.Empty;        
        public string Nombre { get; init; } = string.Empty;
        public string Apellido { get; init; } = string.Empty;
        public string Direccion { get; init; } = string.Empty;
        public string Telefono { get; init; } = string.Empty;
        public bool Estado { get; set; }
        public long EmpresaId { get; set; }
        public string Rol { get; set; }=string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty; 
    }
}
