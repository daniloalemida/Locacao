using ComunicadoSinistro.Applications.Interfaces;
using ComunicadoSinistro.Applications.Models;
using ComunicadoSinistro.Applications.Result;
using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistro.Domain.Entities.Usuarios;
using Flunt.Notifications;
using Locacao.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Veiculo;
using Locacao.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicadoSinistro.Applications
{
    public class LoginApplication : ILoginApplication
    {
        private readonly IClienteRepositorio _cliente;
        private readonly ICriptografarServico _criptografia;
        private readonly IContratoRepositorio _contrato;
        private readonly IComunicadoSinistroRepositorio _sinistro;
        private readonly ICondutorRepositorio _condutor;
        private readonly IVeiculoRepositorio _veiculo;
        private readonly ITerceiroRepositorio _terceiro;
        private readonly IReboqueRepositorio _reboque;

        public LoginApplication(IClienteRepositorio cli, ICriptografarServico cri, IContratoRepositorio cont, 
            IComunicadoSinistroRepositorio sinistro, ICondutorRepositorio condutor, IVeiculoRepositorio veiculo,
            ITerceiroRepositorio terceiro, IReboqueRepositorio reboque)
        {
            _cliente = cli;
            _criptografia = cri;
            _contrato = cont;
            _sinistro = sinistro;
            _condutor = condutor;
            _veiculo = veiculo;
            _terceiro = terceiro;
            _reboque = reboque;
        }

        public Result<LoginRetornoModel> Login(string login, string senha)
        {

            var cliente = _cliente.GetByCPF(login);

            if (cliente == null)
            {
                if(_criptografia.VerifyPasswordHash(senha, cliente.Result.PasswordHash, cliente.Result.PasswordSalt))
                {
                    var sinistros = _sinistro.GetByCliente(cliente.Result.Id);

                    List<SinistroRetornoModel> listaHistoricoSinistro = new List<SinistroRetornoModel>();
                    List<ContratoRetornoModel> listaDadosContratosAtivos = new List<ContratoRetornoModel>();

                    if (sinistros.Count > 0)
                    {
                        foreach (var sinistro in sinistros)
                        {
                            //buscar o condutor
                            var condutor = _condutor.GetById(sinistro.CodCondutorResponsavel).Result;

                            //buscar o veiculo
                            var veiculo = _veiculo.GetById(sinistro.CodVeiculo).Result;

                            // if terceriro identificado buscar terceiro
                            Terceiro terceiro = new Terceiro();
                            if (sinistro.TerceiroIdentificado)
                            {
                                int codTerceiro = sinistro.CodTerceiro.GetValueOrDefault();  
                                terceiro = _terceiro.GetById(codTerceiro).Result;
                            }

                            // if tem reboque buscar reboque
                            Reboque reboque = new Reboque();
                            if (sinistro.TemRoboque)
                            {
                                int codReboque =  sinistro.CodReboque.GetValueOrDefault();
                                reboque = _reboque.GetById(codReboque).Result;
                            }

                            listaHistoricoSinistro.Add(new SinistroRetornoModel()
                            {
                                CodSinistro = sinistro.Id,
                                CodContrato = sinistro.CodContrato,
                                Condutor = condutor,
                                Carro = veiculo,
                                Cliente = cliente.Result,
                                DataSinistro = sinistro.DataSinistro,
                                DescricaoOcorrido = sinistro.DescricaoSinistro,
                                TerceiroEnvolvido = sinistro.TerceiroEnvolvido,
                                TerceiroResponsavel = sinistro.TerceiroResponsavel,
                                AutorizoSeguro = sinistro.AutorizoSeguro,
                                TerceiroIdentificado = sinistro.TerceiroIdentificado,
                                Terceiro = terceiro,
                                CEP = sinistro.CEP,
                                Logradouro = sinistro.Logradouro,
                                Numero = sinistro.Numero,
                                Complemento = sinistro.Complemento,
                                Bairro = sinistro.Bairro,
                                Cidade = sinistro.Cidade,
                                UF = sinistro.UF,
                                BOEnviado = sinistro.BOEnviado,
                                TemReboque = sinistro.TemRoboque,
                                Reboque = reboque
                            });
                        }
                    }

                    var contratos = _contrato.GetByCliente(cliente.Id);

                    if (contratos.Count > 0)
                    {
                        foreach (var contrato in contratos)
                        {
                            var veiculo = _veiculo.GetById(contrato.CodVeiculo).Result;

                            //List<Condutor> 
                            var condutores = _condutor.GetByContrato(contrato.Id);

                            listaDadosContratosAtivos.Add(new ContratoRetornoModel() {
                                CodContrato = contrato.Id, 
                                Cliente = cliente.Result,
                                VeiculoAlugado = veiculo,
                                Condutores = condutores
                            });
                        }
                    }

                    return Result<LoginRetornoModel>.Ok(new LoginRetornoModel()
                    {
                        HistoricoSinistro = listaHistoricoSinistro,
                        DadosContratosAtivos = listaDadosContratosAtivos
                    });
                }
                else
                {
                    return Result<LoginRetornoModel>.Error(new List<Notification>() { new Notification(nameof(LoginRetornoModel), "Senha não confere") });
                }
            }
            else
            {
                return Result<LoginRetornoModel>.Error(new List<Notification>() { new Notification(nameof(LoginRetornoModel), "Cliente não existe") });
            }



            throw new System.NotImplementedException();
        }

        public bool RecuperarSeha(string login, string senha)
        {
            throw new System.NotImplementedException();
        }
    }
}
