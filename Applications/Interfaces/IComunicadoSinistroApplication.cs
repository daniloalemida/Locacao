using ComunicadoSinistro.Applications.Models;
using ComunicadoSinistro.Applications.Result;
using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using Locacao.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Applications.Interfaces
{
    public interface IComunicadoSinistroApplication
    {
        Result<ComunicadoSinistroRetornoModel> CadastrarSinistro(ComunicadoDeSinistroModel comunicado);
    }
}
