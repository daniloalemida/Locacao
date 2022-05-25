using System;
using Locacao.Domain.Entities;
using Locacao.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Veiculo;

namespace Locacao
{
    public class Contrato : Entity
    {
        public int CodCliente { get; set; }
        public int CodVeiculo { get; set; }
        public int CodAgencia { get; set; }
        public Double TotalDiariasLocacao { get; set; }
        public Double ValorTotal { get; set; }
        public string Placa { get; set; }
        public DateTime DataRetirada { get; set; }
        public int CodAgenciaRetirada {get; set;}
        public int CodAgenciaDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool LocacaoAtiva { get; set; } 
    }
}