using Mensajeria.DTOs.Motos;
using Mensajeria.UseCasesPorts.Turnos.MotosDispo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Turnos
{
    public class GetMotoDisponiblePresenter : IMotoDisponibleOutPutPort, IPresenter<IEnumerable<MotoDTO>>
    {
        public IEnumerable<MotoDTO> Content { get; private set; }

        public Task Handle(IEnumerable<MotoDTO> motos)
        {
            Content = motos;
            return Task.CompletedTask;
        }
    }
}
