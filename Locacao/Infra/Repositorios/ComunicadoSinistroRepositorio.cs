using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Locacao.Infra.Repositorios
{
    public class ComunicadoSinistroRepositorio : EntityRepositorio<ComunicadoDeSinistro>, IComunicadoSinistroRepositorio
    {
        public ComunicadoSinistroRepositorio(EntityContext context) : base(context)
        {            
        }

        public List<ComunicadoDeSinistro> GetByCliente(int cliente)
        {
            var contratos = _context.Set<ComunicadoDeSinistro>().ToListAsync();

            List<ComunicadoDeSinistro> retorno = contratos.Result.FindAll(e => e.CodCliente == cliente);

            return retorno;
        }

    }
}