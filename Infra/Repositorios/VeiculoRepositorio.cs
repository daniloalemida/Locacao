using System.Threading.Tasks;
using Locacao.Domain.Entities.Veiculo;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.Repositorios
{
    public class VeiculoRepositorio : EntityRepositorio<Veiculo>, IVeiculoRepositorio
    {
        public VeiculoRepositorio(EntityContext context) : base(context)
        {
        }

        public async Task<Veiculo> GetByPlaca(string placa)
        {
            return await _context.Set<Veiculo>().FirstOrDefaultAsync(e => e.Placa == placa);
        }
    }
}