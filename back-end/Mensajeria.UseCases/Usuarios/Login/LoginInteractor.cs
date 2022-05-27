
using Mensajeria.DTOs;
using Mensajeria.DTOs.Usuarios;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCases.Usuarios.Settings;
using Mensajeria.UseCasesPorts.Usuarios;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Mensajeria.UseCases.Login
{
    public class LoginInteractor : ILoginInputPort
    {
        private readonly IUsuarioRepository Repository;
        private readonly ILoginOutPutPort OutputPort;
        private readonly JwtSettings jwtSettings;

        public LoginInteractor(IUsuarioRepository repository, ILoginOutPutPort outputPort, IOptions<JwtSettings> jwtSettings)
        {
            Repository = repository;
            OutputPort = outputPort;
            this.jwtSettings = jwtSettings.Value;
        }

        public Task Handle(LoginDTO login)
        {
           var usuario= Repository.Login(login);

            if (usuario == null)
            {
                throw new Exception($"El usuario {login.UserName} no existe");
            }
            usuario.Token = new JwtSecurityTokenHandler().WriteToken(GeneraToken.GeneratorToken(usuario, this.jwtSettings));

            OutputPort.Handle(usuario);
            return Task.CompletedTask;
        }


    }
}
