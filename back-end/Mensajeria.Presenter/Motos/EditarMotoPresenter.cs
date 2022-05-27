using Mensajeria.DTOs.Motos;
using Mensajeria.UseCasesPorts.Motos.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Motos
{
    public class EditarMotoPresenter : IEditarMotoOutPutPort, IPresenter<MotoDTO>
    {
        public MotoDTO Content { get; private set; }
        public Task Handle(MotoDTO moto)
        {
            Content = moto;
            return Task.CompletedTask;
        }
    }
}
