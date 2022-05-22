using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using System.Collections.Generic;

namespace ComunicadoSinistro.Applications.Models
{
    public class LoginRetornoModel
    {
        public List<SinistroRetornoModel> HistoricoSinistro { get; set; }
        public List<ContratoRetornoModel> DadosContratosAtivos { get; set; }
    }
}
