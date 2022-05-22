using System.Threading.Tasks;
using Locacao.Domain.Entities.Usuarios;

namespace Locacao.Domain.Interfaces
{
    public interface IClienteRepositorio : IEntityRepositorio<Cliente>
    {
        Task<Cliente> GetByCPF(string CPF);

        bool CPFValid(string CPF);
         
    }
}