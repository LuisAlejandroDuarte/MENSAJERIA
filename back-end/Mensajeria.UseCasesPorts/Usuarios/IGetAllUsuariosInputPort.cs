using Mensajeria.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCasesPorts
{
    public interface IGetAllUsuariosInputPort
    {
        Task Handle(long EmpresaId);
    }

    public interface IGetUsuariosInputPort
    {
        Task Handle(Paginator paginador);
    }
}
