using System;

namespace Locacao.Domain.Entities.Usuarios
{
    public class Condutor : Entity
    {
        public int CodContrato { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Data_nasc { get; set; }        
        public string Celular { get; set; }
        public string Email { get; set; }        
    }
}