using Mensajeria.Entities.Interfaces;
using Mensajeria.RepositoryEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.RepositoryEFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        readonly MensajeriaContext Context;

        public UnitOfWork(MensajeriaContext context)
        {
            Context = context;
        }

        public Task<int> SaveChanges()
        {
            //Crear Excepciones
            return Context.SaveChangesAsync();
        }
    }
}
