using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Domain.Entities.ComunicadoSinistro
{
    public class Reboque : Entity
    {
        public bool Agendar { get; set; }
        public DateTime Data { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public int IdAgenciaDestino { get; set; }
    }
}
