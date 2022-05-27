using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Propietarios.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Propietarios.Get
{
    public class GetPropietarioInteractor : IGetPropietarioInPutPort
    {
        readonly IPropietarioRepository repository;
        readonly IGetPropietarioOutPutPort output;

        public GetPropietarioInteractor(IPropietarioRepository repository, IGetPropietarioOutPutPort output)
        {
            this.repository = repository;
            this.output = output;
        }

        public Task Handle(long Id)
        {
            var propietario =this.repository.GetPropietario(Id);
            this.output.Handle(propietario);
            return Task.CompletedTask;
        }
    }
}
