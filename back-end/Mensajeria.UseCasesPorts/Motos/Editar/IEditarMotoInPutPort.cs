using Mensajeria.DTOs.Motos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCasesPorts.Motos.Editar
{
    public interface IEditarMotoInPutPort
    {
        Task Handle(MotoDTO moto);
    }
}
