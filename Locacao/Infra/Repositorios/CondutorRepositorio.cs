using Locacao.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Veiculo;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Locacao.Infra.Repositorios
{
    public class CondutorRepositorio : EntityRepositorio<Condutor>, ICondutorRepositorio
    {
        public CondutorRepositorio(EntityContext context) : base(context)
        {
            
        }

        public List<Condutor> GetByContrato(int codcontrato)
        {
            var condutores = _context.Set<Condutor>().ToListAsync();

            List<Condutor> retorno = condutores.Result.FindAll(e => e.CodContrato == codcontrato);

            return retorno;
        }
    }
}