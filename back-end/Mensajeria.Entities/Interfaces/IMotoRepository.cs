using Mensajeria.DTOs;
using Mensajeria.DTOs.Motos;
using Mensajeria.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Entities.Interfaces
{
    public interface IMotoRepository
    {
        ResultDataTable GetAll(Paginator paginator);
        void Crear(MotoDTO moto);
        void Actualizar(MotoDTO moto);
        MotoDTO GetMoto(long Id);
    }
}
