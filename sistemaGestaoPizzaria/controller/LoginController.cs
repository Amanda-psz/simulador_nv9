using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaGestaoPizzaria.services;
using sistemaGestaoPizzaria.usuario;

namespace sistemaGestaoPizzaria.controller
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]

        public IActionResult Login([FromBody] UsuarioRequest usuarioRequest)
        {
            var usuario = UsuarioRepository.Get(usuarioRequest.nome, usuarioRequest.senha);
            if (usuario == null)
            {
                return NotFound(new { mensagem = "Usuário ou senha inválidos" });
            }

            var token = TokenService.GenerateToken(usuario);

            usuario.Senha = "";

            return Ok(new
            {
                usuario = usuario,
                token = token
            });
        }
    }
}
