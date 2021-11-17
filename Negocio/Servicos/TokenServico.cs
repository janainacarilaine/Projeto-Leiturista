using Business.Interfaces.Servicos;
using Business.Modelos;
using Business.Seguranca;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Servicos
{
    public class TokenServico : ITokenServico
    {
        public string GerarToken(Usuario usuario)
        {
            var manipuladorToken = new JwtSecurityTokenHandler();            
            var chave = Encoding.ASCII.GetBytes(Token.Segredo);

            var descritorToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Funcao)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256)
            };

            return manipuladorToken.WriteToken(manipuladorToken.CreateToken(descritorToken));

        }
    }
}
