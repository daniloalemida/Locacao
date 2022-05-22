using System.Threading.Tasks;
using Locacao.Domain.Entities.Veiculo;
using Locacao.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController : ControllerBase    
    {
        private readonly IContratoRepositorio _rep;

        public ContratoController(IContratoRepositorio rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rep.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rep.GetById(id));
        }

        [HttpGet("{placa}")]
        public async Task<IActionResult> GetByPlaca(string placa)
        {
            return Ok(await _rep.GetByPlaca(placa));
        }

        [HttpPost]
         public async Task<IActionResult> Create(Contrato contrato)
         {
             return Ok(await _rep.Create(contrato));
         }

        [HttpPut]
        public async Task<IActionResult> Update(Contrato contrato)
        {
            return Ok(await _rep.Update(contrato));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _rep.Delete(id));
        }        
    }
}