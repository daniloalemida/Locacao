using System.Threading.Tasks;
using Locacao.Domain.Entities.Veiculo;
using Locacao.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloVeiculoController : ControllerBase
    {
        private readonly IModeloVeiculoRepositorio _rep;

        public ModeloVeiculoController(IModeloVeiculoRepositorio rep)
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
        public async Task<IActionResult> Create(ModeloVeiculo modelo)
        {
            var retorno = await _rep.Create(modelo);
            return Ok(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ModeloVeiculo modelo)
        {
            return Ok(await _rep.Update(modelo));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            return Ok(await _rep.Delete(id));
        }       
        
    }
}