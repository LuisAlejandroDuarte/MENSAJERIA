
namespace Mensajeria.Entities.POCOs
{
    public class Propietario
    {
        public long Id { get; set; }
        public long EmpresaId { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string Nombre { get; set; }=string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public bool? Estado { get; set; }

        public virtual Empresa? Empresa { get; set; }

    }
}
