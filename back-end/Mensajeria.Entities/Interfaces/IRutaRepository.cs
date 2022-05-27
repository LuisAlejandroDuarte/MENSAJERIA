using Mensajeria.DTOs.Rutas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Entities.Interfaces
{
    public interface IRutaRepository
    {
        IEnumerable<RutaDTO> GetAllDate(long empresaId);
        RutaDTO Crear(RutaDTO ruta);

        RutaDTO GetRutaByTurno(long turnoId);        

        RutaDTO Editar(RutaDTO ruta);
    }
}
