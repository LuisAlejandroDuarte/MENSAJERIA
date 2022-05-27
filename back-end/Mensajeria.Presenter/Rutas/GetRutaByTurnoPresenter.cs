using Mensajeria.DTOs.Rutas;
using Mensajeria.UseCasesPorts.Rutas.GetByTurno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Rutas
{
    public class GetRutaByTurnoPresenter : IGetRutaByTurnoOutPutPort, IPresenter<RutaDTO>
    {
        public RutaDTO Content { get; private set; }

        public Task Handle(RutaDTO ruta)
        {
            Content = ruta;
            return Task.CompletedTask;
        }
    }
}
