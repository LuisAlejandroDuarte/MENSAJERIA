using Mensajeria.DTOs.Turnos;
using Mensajeria.UseCases.Turnos.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Turnos
{
    public class DeleteTurnoPresenter : IDeleteTurnoOutPutPort, IPresenter<TurnoDTO>
    {
        public TurnoDTO Content { get; private set; }

        public Task Handle(TurnoDTO turno)
        {
            Content = turno;
            return Task.CompletedTask;
        }
    }
}
