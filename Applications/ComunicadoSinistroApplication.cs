using ComunicadoSinistro.Applications.Interfaces;
using ComunicadoSinistro.Applications.Models;
using ComunicadoSinistro.Applications.Result;
using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistro.Domain.Entities.Usuarios;
using Flunt.Notifications;
using Locacao;
using Locacao.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Applications
{
    public class ComunicadoSinistroApplication : IComunicadoSinistroApplication
    {
        private readonly IContratoRepositorio _contratoRepositorio;
        private readonly IReboqueRepositorio _reboqueRepositorio;
        private readonly IComunicadoSinistroRepositorio _comunicadoSinistroRepositorio;
        private readonly ITerceiroRepositorio _terceiroRepositorio;

        public ComunicadoSinistroApplication(IContratoRepositorio contratoRepositorio, IReboqueRepositorio reboqueRepositorio,
            IComunicadoSinistroRepositorio comunicadoSinistroRepositorio, ITerceiroRepositorio terceiroRepositorio)
        {
            _contratoRepositorio = contratoRepositorio;
            _reboqueRepositorio = reboqueRepositorio;
            _comunicadoSinistroRepositorio = comunicadoSinistroRepositorio;
            _terceiroRepositorio = terceiroRepositorio;
        }
        public Result<ComunicadoSinistroRetornoModel> CadastrarSinistro(ComunicadoDeSinistroModel comunicado)
        {
            ComunicadoSinistroRetornoModel retorno = new ComunicadoSinistroRetornoModel();
            Reboque retornoReboque = new Reboque();
            if (comunicado.TemRoboque)
            {
                Reboque reboque = new Reboque()
                {
                    Agendar = comunicado.Reboque.Agendar,
                    Data = comunicado.Reboque.Data,
                    CEP = comunicado.Reboque.CEP,
                    Logradouro = comunicado.Reboque.Logradouro,
                    Numero = comunicado.Reboque.Numero,
                    Complemento = comunicado.Reboque.Complemento,
                    Bairro = comunicado.Reboque.Bairro,
                    Cidade = comunicado.Reboque.Cidade,
                    UF = comunicado.Reboque.UF
                };

                if (reboque.Agendar)
                {
                    retorno.MensagemReboque = $"Reboque agendado para {reboque.Data}, com sucesos!";
                    retornoReboque =  _reboqueRepositorio.CreateAndReturn(reboque).Result;

                    if (!(retornoReboque.Id > 0))
                    {
                        return Result<ComunicadoSinistroRetornoModel>.Error(new List<Notification>() {
                            new Notification(nameof(ComunicadoSinistroRetornoModel), "Erro ao Salvar reboque") });
                    }
                }
                else
                {
                    retorno.MensagemReboque = $"O Carro tem que ser entregue na agência mais próxima";
                }
                
            }

            ComunicadoDeSinistro sinistro = new ComunicadoDeSinistro()
            {
                CodContrato = comunicado.CodContrato,
                CodVeiculo = comunicado.CodVeiculo,
                CodCliente = comunicado.CodCliente,
                CodCondutorResponsavel = comunicado.CodCondutorResponsavel,
                DataSinistro = comunicado.DataSinistro,
                DescricaoSinistro = comunicado.DescricaoSinistro,
                CEP = comunicado.CEP,
                Logradouro = comunicado.Logradouro,
                Numero = comunicado.Numero,
                Complemento = comunicado.Complemento,
                Bairro = comunicado.Bairro,
                Cidade = comunicado.Cidade,
                UF = comunicado.Cidade,
                TerceiroEnvolvido = comunicado. TerceiroEnvolvido,
                TerceiroIdentificado = comunicado.TerceiroIdentificado,
                TerceiroResponsavel = comunicado.TerceiroResponsável,
                AutorizoSeguro = comunicado.AutorizoSeguro,
                TemRoboque = comunicado.TemRoboque,
                CodReboque = retornoReboque.Id,
                BOEnviado = comunicado.BOEnviado
            };

            var retornoComunicado = _comunicadoSinistroRepositorio.CreateAndReturn(sinistro).Result;

            if (!(retornoComunicado?.Id > 0))
            {
                return Result<ComunicadoSinistroRetornoModel>.Error(new List<Notification>() {
                    new Notification(nameof(ComunicadoSinistroRetornoModel), "Erro ao Salvar Comunicado de Sinistro") });
            }
            
            retorno.CodSinistro = retornoComunicado.Id;
            
            if (comunicado.TerceiroIdentificado)
            {
                foreach (var terceiro in comunicado.Terceiros)
                {
                    Terceiro terce = new Terceiro()
                    {
                        CodSinistro = retornoComunicado.Id,
                        Nome = terceiro.Nome,
                        Email = terceiro.Email,
                        Telefone = terceiro.Telefone
                    };
                    var retornoTerceiro = _terceiroRepositorio.Create(terce).Result;
                    retorno.MensagemTerceiro = "Terceiros Cadastrados com Sucesso!";

                    if (retornoTerceiro)
                    {
                        return Result<ComunicadoSinistroRetornoModel>.Error(new List<Notification>() {
                            new Notification(nameof(ComunicadoSinistroRetornoModel), $"Erro ao cadastrar terceiro: {terceiro.Nome}") });

                    }
                }
            }            
            return Result<ComunicadoSinistroRetornoModel>.Ok(retorno);
        }
    }
}
