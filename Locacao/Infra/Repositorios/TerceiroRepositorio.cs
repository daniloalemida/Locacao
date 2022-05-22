using ComunicadoSinistro.Domain.Entities.Usuarios;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;

namespace Locacao.Infra.Repositorios
{
    public class TerceiroRepositorio : EntityRepositorio<Terceiro>, ITerceiroRepositorio
    {
        public TerceiroRepositorio(EntityContext context) : base(context)
        {
        }
        
    }
}