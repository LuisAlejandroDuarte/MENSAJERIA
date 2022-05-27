using Mensajeria.Entities.POCOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.RepositoryEFCore.DataContext
{
    public class MensajeriaContext :DbContext
    {
        public MensajeriaContext(DbContextOptions<MensajeriaContext> options):base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
