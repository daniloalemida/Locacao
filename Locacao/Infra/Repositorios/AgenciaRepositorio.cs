using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;

namespace Locacao.Infra.Repositorios
{
    public class AgenciaRepositorio : EntityRepositorio<Agencia>, IAgenciaRepositorio
    {
        public AgenciaRepositorio(EntityContext context) : base(context)
        {
        }
        
    }
}