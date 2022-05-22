using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Applications.Models
{
    public class ComunicadoSinistroRetornoModel
    {
        public int CodSinistro { get; set; }
        public string MensagemReboque { get; set; }
        public string MensagemTerceiro { get; set; }

    }
}
