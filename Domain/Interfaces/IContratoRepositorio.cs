using System.Collections.Generic;
using System.Threading.Tasks;
using Locacao.Domain.Entities.Veiculo;

namespace Locacao.Domain.Interfaces
{
    public interface IContratoRepositorio : IEntityRepositorio<Contrato>
    {
        Task<Contrato> GetByPlaca(string placa);
        List<Contrato> GetByCliente(int cliente);

    }
}