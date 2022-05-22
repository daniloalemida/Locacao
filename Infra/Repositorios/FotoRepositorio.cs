using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;

namespace Locacao.Infra.Repositorios
{
    public class FotoRepositorio : EntityRepositorio<Foto>, IFotoRepositorio
    {
        public FotoRepositorio(EntityContext context) : base(context)
        {
        }
        
    }
}