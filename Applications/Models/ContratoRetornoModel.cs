using Locacao.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Veiculo;
using System.Collections.Generic;

namespace ComunicadoSinistro.Applications.Models
{
    public class ContratoRetornoModel
    {
        public int CodContrato { get; set; }
        public Cliente Cliente { get; set; }
        public Veiculo VeiculoAlugado { get; set; }
        public List<Condutor> Condutores { get; set; }
    }
}
