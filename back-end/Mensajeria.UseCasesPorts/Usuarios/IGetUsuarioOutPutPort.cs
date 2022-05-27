using Mensajeria.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCasesPorts.Usuarios
{
    public interface IGetUsuarioOutPutPort
    {
        Task Handle(UsuarioDTO usuario);
    }
}
