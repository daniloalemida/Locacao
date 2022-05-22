using System.Threading.Tasks;
using Locacao.Domain.Entities.Usuarios;
using Locacao.Domain.Interfaces;
using Locacao.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.Repositorios
{
    public class ClienteRepositorio : EntityRepositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(EntityContext context) : base(context)
        {
        }

        public async Task<Cliente> GetByCPF(string CPF)
        {
            return await _context.Set<Cliente>().FirstOrDefaultAsync(e => e.CPF == CPF);
        }

        public bool CPFValid(string CPF)
        {
            var _cpf = CPF;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            _cpf = _cpf.Trim();
            _cpf = _cpf.Replace(".", "").Replace("-", "");
            if (_cpf.Length != 11)
                return false;
            tempCpf = _cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return _cpf.EndsWith(digito);
        }

       
    }
        
}