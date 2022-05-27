using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.RepositoryEFCore.DataContext
{
    public class MensajeriaContextFactory : IDesignTimeDbContextFactory<MensajeriaContext>
    {
        public MensajeriaContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<MensajeriaContext>();

            OptionsBuilder.UseSqlServer("Data Source=CASA;Initial Catalog=MENSAJERIA;Integrated Security=true").EnableSensitiveDataLogging();

            return new MensajeriaContext(OptionsBuilder.Options);
        }
    }
}
