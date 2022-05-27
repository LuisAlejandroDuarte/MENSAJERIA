using Mensajeria.Presenter.Motos;
using Mensajeria.Presenter.Propietarios;
using Mensajeria.Presenter.Reportes;
using Mensajeria.Presenter.Rutas;
using Mensajeria.Presenter.Turnos;
using Mensajeria.Presenter.Usuarios;
using Mensajeria.UseCases.Turnos.Delete;
using Mensajeria.UseCasesPorts;
using Mensajeria.UseCasesPorts.Motos.Crear;
using Mensajeria.UseCasesPorts.Motos.Editar;
using Mensajeria.UseCasesPorts.Motos.Get;
using Mensajeria.UseCasesPorts.Motos.GetAll;
using Mensajeria.UseCasesPorts.Propietarios.Crear;
using Mensajeria.UseCasesPorts.Propietarios.Editar;
using Mensajeria.UseCasesPorts.Propietarios.Get;
using Mensajeria.UseCasesPorts.Propietarios.GetAll;
using Mensajeria.UseCasesPorts.Reporte;
using Mensajeria.UseCasesPorts.Rutas.Crear;
using Mensajeria.UseCasesPorts.Rutas.Editar;
using Mensajeria.UseCasesPorts.Rutas.Get;
using Mensajeria.UseCasesPorts.Rutas.GetByTurno;
using Mensajeria.UseCasesPorts.Turnos.Crear;
using Mensajeria.UseCasesPorts.Turnos.Editar;
using Mensajeria.UseCasesPorts.Turnos.Get;
using Mensajeria.UseCasesPorts.Turnos.GetAll;
using Mensajeria.UseCasesPorts.Turnos.MotosDispo;
using Mensajeria.UseCasesPorts.Usuarios;
using Microsoft.Extensions.DependencyInjection;

namespace Mensajeria.Presenter
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICrearUsuarioOutPutPort, CrearUsuarioPresenter>();
            services.AddScoped<ILoginOutPutPort, LoginPresenter>();
            services.AddScoped<IGetAllUsuariosOutputPort, GetAllUsuariosPresenter>();
            services.AddScoped<IGetUsuariosOutPutPort, GetUsuariosPresenter>();
            services.AddScoped<IGetUsuarioOutPutPort, GetUsuarioPresenter>();
            services.AddScoped<IRenewTokenOutPutPort, RenewTokenPresenter>();
            services.AddScoped<IChangePasswordOutPutPort, ChangePasswordPresenter>();
            services.AddScoped<IActualizarUsuarioOutPutPort, ActualizarUsuarioPresenter>();

            //Propietarios
            services.AddScoped<IGetAllPropietarioOutPutPort, GetAllPropietariosPresenter>();
            services.AddScoped<IEditarPropietarioOutPutPort, EditarPropietarioPresenter>();
            services.AddScoped<ICrearPropietarioOutPutPort, CrearPropietarioPresenter>();
            services.AddScoped<IGetPropietarioOutPutPort, GetPropietarioPresenter>();
            services.AddScoped<IGetPropietariosOutPutPort, GetPropietariosPresenter>();

            //Motos
            services.AddScoped<IGetAllMotoOutPutPort, GetAllMotoPresenter>();
            services.AddScoped<IEditarMotoOutPutPort, EditarMotoPresenter>();
            services.AddScoped<ICrearMotoOutPutPort, CrearMotoPresenter>();
            services.AddScoped<IGetMotoOutPutPort, GetMotoPresenter>();

            //Turnos
            services.AddScoped<IObtenerTurnoEsperaOutPutPort, ObtenerEsperaPresenter>();
            services.AddScoped<ICrearTurnoOutPutPort, CrearTurnoPresenter>();
            services.AddScoped<IMotoDisponibleOutPutPort, GetMotoDisponiblePresenter>();
            services.AddScoped<IGetTurnoOutPutPort, GetTurnoPresenter>();
            services.AddScoped<IDeleteTurnoOutPutPort, DeleteTurnoPresenter>();
            services.AddScoped<IEditarTurnoOutPutPort, EditarTurnoPresenter>();

            //Rutas
            services.AddScoped<ICrearRutaOutPutPort, CrearRutaPresenter>();
            services.AddScoped<IEditarRutaOutPutPort, EditarRutaPresenter>();
            services.AddScoped<IGetAllDateOutPutPort, GetAllDatePresenter>();
            services.AddScoped<IGetRutaByTurnoOutPutPort, GetRutaByTurnoPresenter>();

            //Reportes
            services.AddScoped<IGetReporteFacturaOutPutPort, GetReporteFacturaPresenter>();

            return services;
        }
    }
}
