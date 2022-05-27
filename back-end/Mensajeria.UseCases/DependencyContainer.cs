
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mensajeria.UseCases.CrearUsuario;
using Mensajeria.UseCases.GetAllUsuarios;
using Mensajeria.UseCases.Login;
using Mensajeria.UseCases.Usuarios.Settings;
using Mensajeria.UseCasesPorts;
using Mensajeria.UseCasesPorts.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Mensajeria.UseCases.Usuarios.Login;
using Mensajeria.UseCases.Usuarios.ActualizarUsuario;
using Mensajeria.UseCases.Usuarios.GetUsuario;
using Mensajeria.UseCases.Usuarios.ChangePassword;
using Mensajeria.UseCasesPorts.Propietarios.GetAll;
using Mensajeria.UseCases.Propietarios.GetAllPropietarios;
using Mensajeria.UseCasesPorts.Propietarios.Editar;
using Mensajeria.UseCases.Propietarios.Editar;
using Mensajeria.UseCasesPorts.Propietarios.Get;
using Mensajeria.UseCases.Propietarios.Get;
using Mensajeria.UseCasesPorts.Propietarios.Crear;
using Mensajeria.UseCases.Propietarios.CrearPropietario;
using Mensajeria.UseCasesPorts.Motos.GetAll;
using Mensajeria.UseCases.Motos.GetAll;
using Mensajeria.UseCasesPorts.Motos.Editar;
using Mensajeria.UseCasesPorts.Motos.Get;
using Mensajeria.UseCasesPorts.Motos.Crear;
using Mensajeria.UseCases.Motos.Editar;
using Mensajeria.UseCases.Motos.Get;
using Mensajeria.UseCases.Motos.Crear;
using Mensajeria.UseCasesPorts.Turnos.Crear;
using Mensajeria.UseCases.Turnos.Crear;
using Mensajeria.UseCasesPorts.Turnos.GetAll;
using Mensajeria.UseCases.Turnos.Get;
using Mensajeria.UseCasesPorts.Turnos.MotosDispo;
using Mensajeria.UseCases.Turnos.MotoDispo;
using Mensajeria.UseCasesPorts.Rutas.Crear;
using Mensajeria.UseCases.Rutas.Crear;
using Mensajeria.UseCasesPorts.Rutas.Editar;
using Mensajeria.UseCases.Rutas.Editar;
using Mensajeria.UseCasesPorts.Rutas.Get;
using Mensajeria.UseCases.Rutas.Get;
using Mensajeria.UseCasesPorts.Turnos.Get;
using Mensajeria.UseCasesPorts.Rutas.GetByTurno;
using Mensajeria.UseCases.Rutas.GetRutaByTurno;
using Mensajeria.UseCasesPorts.Turnos.Delete;
using Mensajeria.UseCases.Turnos.Delete;
using Mensajeria.UseCases.Turnos.Editar;
using Mensajeria.UseCasesPorts.Turnos.Editar;
using Mensajeria.UseCasesPorts.Reporte;
using Mensajeria.UseCases.Reportes.Factura;

namespace Mensajeria.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddTransient<ICrearUsuarioInputPort, CrearUsuarioInteractor>();
            services.AddTransient<IGetAllUsuariosInputPort, GetAllUsuariosInteractor>();
            services.AddTransient<IGetUsuariosInputPort, GetUsuariosInteractor>();
            services.AddTransient<IGetUsuarioInPutPort, GetUsuarioInteractor>();
            services.AddTransient<ILoginInputPort, LoginInteractor>();
            services.AddTransient<IRenewTokenInPutPort, ReNewTokenInteractor>();
            services.AddTransient<IActualizarUsuarioInPutPort, ActualizarUsuarioInteractor>();
            services.AddTransient<IChangePasswordInPutPort, ChangePasswordInteractor>();

            //Propietarios
            services.AddTransient<IGetAllPropietariosInPutPort, GetAllPropietariosInteractor>();
            services.AddTransient<IEditarPropietarioInPutPort, EditarPropietarioInteractor>();
            services.AddTransient<IGetPropietarioInPutPort, GetPropietarioInteractor>();
            services.AddTransient<IGetPropietariosInPutPort, GetPropietariosInteractor>();
            services.AddTransient<ICrearPropietarioInPutPort, CrearPropietarioInteractor>();

            //Motos
            services.AddTransient<IGetAllMotoInPutPort, GetAllMotoInteractor>();
            services.AddTransient<IEditarMotoInPutPort, EditarMotoInteractor>();
            services.AddTransient<IGetMotoInPutPort, GetMotoInteractor>();
            services.AddTransient<ICrearMotoInPutPort, CrearMotoInteractor>();

            //Turnos
            services.AddTransient<ICrearTurnoInPutPort, CrearTurnoInteractor>();
            services.AddTransient<IObtenerTurnoEsperaInPutPort, ObtenerTurnoInteractor>();
            services.AddTransient<IMotoDisponibleInPutPort, GetMotoDisponibleInteractor>();
            services.AddTransient<IGetTurnoInPutPort, GetTurnoInteractor>();
            services.AddTransient<IDeleteTurnoInPutPort, DeleteTurnoInteractor>();
            services.AddTransient<IEditarTurnoInPutPort, EditarTurnoInteractor>();

            //Rutas
            services.AddTransient<ICrearRutaInPutPort, CrearRutaInteractor>();
            services.AddTransient<IEditarRutaInPutPort, EditarRutaInteractor>();
            services.AddTransient<IGetAllDateInPutPort, GetAllDateRutaInteractor>();
            services.AddTransient<IGetRutaByTurnoInPutPort, GetRutaByTurnoInteractor>();

            //Reportes
            services.AddTransient<IGetReporteFacturaInPutPort, GetReporteFacturaInteractor>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            return services;

        }
    }
}
