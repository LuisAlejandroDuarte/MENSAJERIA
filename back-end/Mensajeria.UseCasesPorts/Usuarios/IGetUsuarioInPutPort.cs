using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCasesPorts.Usuarios
{
    public interface IGetUsuarioInPutPort
    {
        Task Handle(long Id);
    }
}
