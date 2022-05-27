using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCasesPorts.Motos.Get
{
    public interface IGetMotoInPutPort
    {
        Task Handle(long Id);
    }
}
