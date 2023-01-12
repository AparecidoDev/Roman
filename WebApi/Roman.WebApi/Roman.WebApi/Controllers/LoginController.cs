using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Roman.WebApi.Domain;
using Roman.WebApi.Interface;
using Roman.WebApi.Repository;
using Roman.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Roman.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _IUsuarioRepository { get; set; }


        public LoginController()
        {
            _IUsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel Login)
        {
            try
            {
                Usuario UsuarioBuscado = _IUsuarioRepository.Login(Login.Email, Login.Senha);

                if (UsuarioBuscado == null)
                {
                    return NotFound("E-mail ou Senha inválidos");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),

                    new Claim("role", UsuarioBuscado.IdTipoUsuario.ToString()),

                    new Claim("nome", UsuarioBuscado.NomeUsuario)                                     

                };

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Roman-Chave-Autenticacao"));

                var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var Token = new JwtSecurityToken(
                    issuer: "Roman.WebApi",
                    audience: "Roman.WebApi",
                    claims: Claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: Creds
                    );

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(Token)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
