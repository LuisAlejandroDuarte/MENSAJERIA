using Mensajeria.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Usuarios.Settings
{
    public static class GeneraToken
    {
        public static JwtSecurityToken GeneratorToken(UsuarioDTO user, JwtSettings jwtSettings)
        {
            //var userClaims = await userManager.GetClaimsAsync(user);
            //var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            roleClaims.Add(new Claim(ClaimTypes.Role, user.Rol));

            //foreach (var role in roles)
            //{
            //    roleClaims.Add(new Claim(ClaimTypes.Role, role));
            //}

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.User) ,
                new Claim(CustomClaimTypes.Uid,user.Id.ToString())
            }.Union(roleClaims);

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

            var signingCredetials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(

                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
                signingCredentials: signingCredetials
           );

            return jwtSecurityToken;
        }
    }
}
