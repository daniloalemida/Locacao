using Locacao.Domain.Entities.Veiculo;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;

namespace Locacao.Infra.Repositorios
{
    public class ModeloVeiculoRepositorio : EntityRepositorio<ModeloVeiculo>, IModeloVeiculoRepositorio
    {
        public ModeloVeiculoRepositorio(EntityContext context) : base(context)
        {
        }
    }
}