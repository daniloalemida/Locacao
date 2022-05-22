using System;
using Locacao.Domain.Enums;

namespace Locacao.Domain.Entities.Veiculo
{
    public class Veiculo : Entity
    {
        public string Placa { get; set; }
        public Double ValorDiaria { get; set; }
        public int CapacidadeTanqueCombustivel { get; set; }
        public int CapacidadePortaMalas { get; set; }
        public string Marca {get; set;}
        public string Modelo {get;set;}
        public int Ano { get; set; }
        public string Categoria { get; set; }
        public string TipoCombustivel {get; set;}
        public string FotoVeiculo {get; set;}
        public bool CarroDisponivel { get; set; }
        public int IdAgencia { get; set; }
    }
}