namespace Mensajeria.Entities.POCOs
{
    public  class Ruta
    {
        public long Id { get; set; }
        public long TurnoId { get; set; }
        public DateTime Inicia { get; set; }
        public DateTime? Termina { get; set; }
        public string Destino { get; set; }=string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public decimal? Valor { get; set; }
        public bool? Estado { get; set; }
        public string Observacion { get; set; } = string.Empty;

        public virtual Turno? Turno { get; set; }
    }
}
