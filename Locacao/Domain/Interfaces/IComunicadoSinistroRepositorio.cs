using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using Locacao.Domain.Entities.Veiculo;
using System.Collections.Generic;

namespace Locacao.Domain.Interfaces
{
    public interface IComunicadoSinistroRepositorio : IEntityRepositorio<ComunicadoDeSinistro>
    {
        List<ComunicadoDeSinistro> GetByCliente(int cliente);

    }
}