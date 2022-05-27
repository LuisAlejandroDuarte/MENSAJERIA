
using Mensajeria.DTOs.Turnos;

namespace Mensajeria.DTOs.Rutas
{
    public class RutaDTO
    {
        public long? Id { get; set; }
        public long? TurnoId { get; set; }
        public DateTime Inicia { get; set; }
        public DateTime? Termina { get; set; }
        public string Destino { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public decimal? Valor { get; set; }
        public bool? Estado { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string NombrePropietario { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;        
    }
}
