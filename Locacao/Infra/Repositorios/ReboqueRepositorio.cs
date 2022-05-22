using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;

namespace Locacao.Infra.Repositorios
{
    public class ReboqueRepositorio : EntityRepositorio<Reboque>, IReboqueRepositorio
    {
        public ReboqueRepositorio(EntityContext context) : base(context)
        {
        }        
    }
}