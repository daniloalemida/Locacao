using Locacao.Domain.Entities.Veiculo;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;

namespace Locacao.Infra.Repositorios
{
    public class MarcaVeiculoRepositorio : EntityRepositorio<MarcaVeiculo>, IMarcaVeiculoRepositorio
    {
        public MarcaVeiculoRepositorio(EntityContext context) : base(context)
        {
        }
    }
}