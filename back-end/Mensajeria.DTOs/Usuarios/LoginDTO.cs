using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.DTOs.Usuarios
{
    public class LoginDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;    
        public long EmpresaId { get; set; } 

    }
}
