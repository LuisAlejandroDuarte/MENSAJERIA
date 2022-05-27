using Mensajeria.DTOs.Turnos;
using Mensajeria.UseCasesPorts.Turnos.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Turnos
{
    public class ObtenerEsperaPresenter : IObtenerTurnoEsperaOutPutPort, IPresenter<IEnumerable<TurnoDTO>>
    {
        public IEnumerable<TurnoDTO> Content { get; private set; }

        public Task Handle(IEnumerable<TurnoDTO> turnos)
        {
            Content = turnos;

            return Task.CompletedTask;
        }
    }
}
