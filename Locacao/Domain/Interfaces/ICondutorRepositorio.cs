using Locacao.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Veiculo;
using System.Collections.Generic;

namespace Locacao.Domain.Interfaces
{
    public interface ICondutorRepositorio : IEntityRepositorio<Condutor>
    {
        List<Condutor> GetByContrato(int codcontrato);

    }
}