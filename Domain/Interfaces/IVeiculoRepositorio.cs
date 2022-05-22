using System.Threading.Tasks;
using Locacao.Domain.Entities.Veiculo;

namespace Locacao.Domain.Interfaces
{
    public interface IVeiculoRepositorio : IEntityRepositorio<Veiculo>
    {
        Task<Veiculo> GetByPlaca(string placa);
         
    }
}