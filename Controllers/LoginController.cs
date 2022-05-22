using ComunicadoSinistro.Applications.Interfaces;
using ComunicadoSinistro.Applications.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginApplication _loginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;

        }

        [HttpPost]
        [ProducesResponseType(typeof(LoginRetornoModel), StatusCodes.Status200OK)]
        public IActionResult Login(string login, string senha)
        {
            try
            {
                var retorno = _loginApplication.Login(login, senha);

                if (retorno.Success)
                {
                    return Ok(retorno);
                }
                return BadRequest(retorno.Notifications);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
