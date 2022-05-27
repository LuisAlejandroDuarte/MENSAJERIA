using Mensajeria.DTOs.Rutas;
using Mensajeria.UseCasesPorts.Rutas.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Rutas
{
    public class GetAllDatePresenter : IGetAllDateOutPutPort, IPresenter<IEnumerable<RutaDTO>>
    {
        public IEnumerable<RutaDTO> Content {get;private set;}

        public Task Handle(IEnumerable<RutaDTO> rutas)
        {
            Content = rutas;
            return Task.CompletedTask;
        }
    }
}
