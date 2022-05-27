using Mensajeria.DTOs;
using Mensajeria.DTOs.Propietarios;
using Mensajeria.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Entities.Interfaces
{
    public interface IPropietarioRepository
    {
        ResultDataTable GetAll(Paginator paginator);
        IEnumerable<PropietarioDTO> GetPropietarios(long empresaId);
        void Crear(PropietarioDTO propietario);
        void Actualizar(PropietarioDTO propietario);
        PropietarioDTO GetPropietario(long Id);
    }
}
