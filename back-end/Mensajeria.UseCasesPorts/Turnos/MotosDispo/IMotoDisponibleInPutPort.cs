using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCasesPorts.Turnos.MotosDispo
{
    public interface IMotoDisponibleInPutPort
    {
        Task Handle(long empresaId);
    }
}
