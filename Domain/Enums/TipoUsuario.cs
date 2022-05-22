using System.ComponentModel;

namespace Locacao.Domain.Enums
{
    public enum TipoUsuario
    {
        [Description("Cliente")]
        Cliente = 1,
        
        [Description("Operador")]
        Operador = 2
    }
}