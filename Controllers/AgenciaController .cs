using System.Threading.Tasks;
using Locacao.Domain.Entities.Veiculo;
using Locacao.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenciaController : ControllerBase
    {
        private readonly IAgenciaRepositorio _rep;

        public AgenciaController(IAgenciaRepositorio rep)
        {
            _rep = rep;
        }
                
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            
            return Ok(await _rep.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rep.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Agencia agencia)
        {
            var retorno = await _rep.Create(agencia);
            return Ok(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Agencia agencia)
        {
            return Ok(await _rep.Update(agencia));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            return Ok(await _rep.Delete(id));
        }       
        
    }
}