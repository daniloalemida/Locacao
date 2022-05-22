using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistro.Domain.Entities.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Applications.Models
{
    public class ComunicadoDeSinistroModel
    {
        public int CodContrato { get; set; }
        public int CodVeiculo { get; set; }
        public int CodCliente { get; set; }
        public int CodCondutorResponsavel { get; set; }
        public DateTime DataSinistro { get; set; }
        public string DescricaoSinistro { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool TerceiroEnvolvido { get; set; }
        public bool TerceiroIdentificado { get; set; }
        public List<Terceiro> Terceiros { get; set; }
        public bool TerceiroResponsável { get; set; }
        public bool AutorizoSeguro { get; set; }
        public string Status { get; set; }
        public bool TemRoboque { get; set; }
        public Reboque Reboque { get; set; }
        public bool BOEnviado { get; set; }
    }
}
