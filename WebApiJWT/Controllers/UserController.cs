using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApiJWT.Entities;
using WebApiJWT.Models;

namespace WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [AllowAnonymous]
        [HttpPost("/api/AdicionaUsuario")]
        public async Task<IActionResult> AdicionaUsuario([FromBody] AddUserRequest login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha) || string.IsNullOrWhiteSpace(login.rg))
                return BadRequest("Falta alguns dados");

            var user = new ApplicationUser
            {
                UserName = login.email,
                Email = login.email,
                RG = login.rg
            };

            var resultado = await _userManager.CreateAsync(user, login.senha);

            if (resultado.Succeeded)
            {
                // Geração de Confirmação caso precise
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                // retorno email 
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                var resultado2 = await _userManager.ConfirmEmailAsync(user, code);

                if (resultado2.Succeeded)
                    return Ok("Usuário Adicionado com Sucesso");
                else
                    return BadRequest("Erro ao confirmar usuários");
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }
         


    }
}