using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Domain.Entities.ComunicadoSinistro
{
    public class Foto : Entity
    {
        public string Base64 { get; set; }
    }
}
