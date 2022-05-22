using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistro.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Veiculo;
using System;
using System.Collections.Generic;

namespace ComunicadoSinistro.Applications.Models
{
    public class SinistroRetornoModel
    {
        public int CodSinistro { get; set; }
        public int CodContrato { get; set; }
        public Condutor Condutor { get; set; }
        public Veiculo Carro { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataSinistro { get; set; }
        public string DescricaoOcorrido { get; set; }
        public bool TerceiroEnvolvido { get; set; }
        public bool TerceiroResponsavel { get; set; }
        public bool AutorizoSeguro { get; set; }
        public bool TerceiroIdentificado { get; set; }
        public Terceiro Terceiro { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool TemReboque { get; set; }
        public Reboque Reboque { get; set; }
        public bool BOEnviado { get; set; }
    
    }
}
