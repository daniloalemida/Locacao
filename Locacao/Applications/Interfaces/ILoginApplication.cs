using ComunicadoSinistro.Applications.Models;
using ComunicadoSinistro.Applications.Result;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Applications.Interfaces
{
    public interface ILoginApplication
    {
        Result<LoginRetornoModel> Login(string login, string senha);

        bool RecuperarSeha(string login, string senha);
    }
}
