using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.DTOs.Turnos
{
    public enum TypeTurnos
    {
        Disponible=1,
        EnRuta=2,
        Terminado=3
    }

    public class TurnoDTO
    {
        public long Id { get; set; }
        public long EmpresaId { get; set; }
        public long MotoId { get; set; }
        public int Posicion { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime? Inicia { get; set; }
        public DateTime? Termina { get; set; }
        public string Placa { get; set; } =string.Empty;
        public string NombrePropietario { get; set; } = string.Empty;
        public TypeTurnos Estado { get; set; }
    }
}
