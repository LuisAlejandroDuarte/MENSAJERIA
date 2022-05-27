﻿using Mensajeria.DTOs.Rutas;
using Mensajeria.UseCasesPorts.Rutas.Crear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Rutas
{
    public class CrearRutaPresenter : ICrearRutaOutPutPort, IPresenter<RutaDTO>
    {
        public RutaDTO Content {get; private set;}

        public Task Handle(RutaDTO ruta)
        {
            Content = ruta;
            return Task.CompletedTask;
        }
    }
}
