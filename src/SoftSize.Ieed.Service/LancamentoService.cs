using System;
using System.Collections.Generic;
using System.Linq;
using SoftSize.Ieed.Model.Factory;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.Service.Specifications;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Service
{
    public class LancamentoService : ILancamentoService
    {
        private IRepository<LancamentoBase> lancamentosBase;
        private IRepository<LancamentoDespesa> lancamentoDespesas;
        private IMovimentoDeCaixaService movimentoDeCaixaService;
        private IRepository<Associado> associados;

        public LancamentoService(
            IMovimentoDeCaixaService movimentoDeCaixaService,
            IRepository<Associado> associados,
            IRepository<LancamentoBase> lancamentosBase,
            IRepository<LancamentoDespesa> lancamentoDespesas)
        {
            this.movimentoDeCaixaService = movimentoDeCaixaService;
            this.associados = associados;
            this.lancamentosBase = lancamentosBase;
            this.lancamentoDespesas = lancamentoDespesas;
        }

        public void IncluirLancamento(LancamentoBase lancamento)
        {
            if (lancamento.Associado != null && AssociadoJaPossuiLancamentoEm(lancamento))
                throw new InvalidOperationException("Este associado já possui um lançamento para esta mensalidade.");
            lancamentosBase.Add(lancamento);
        }


        /// <summary>
        /// Inclui novo lançamento sem validação de lancamento com mesmo centro de custo para o usuario
        /// </summary>
        /// <param name="lancamento"></param>
        public void IncluirLancamentoSemValidacao(LancamentoBase lancamento)
        {
            lancamentosBase.Add(lancamento);
        }

        public IEnumerable<LancamentoBase> ListarLancamentosPor(Guid[] ids)
        {
            return ids.Select(id => lancamentosBase.FindOne(new LancamentosPor(id)));
        }

    
        public IEnumerable<LancamentoBase> ListarLancamentosDo(Associado associado)
        {
            return associados.FindOne(new AssociadoPorId(associado.Id)).LancamentosDoAssociadoEDependentes();
        }

        public IEnumerable<LancamentoDespesa> ListarLancamentosDespesa()
        {
            return lancamentoDespesas;
        }


        public void GerarMensalidadesEmLote(CentroDeCustoLancamento centroDeCustoLancamento)
        {
            foreach (var associado in associados.FindAll(new AssociadosAtivos()))
            {
                    var mensalidade = LancamentoFactory.CriarLancamentoDeMensalidade(associado, centroDeCustoLancamento);
                    IncluirLancamento(mensalidade);
            }
        }

        private bool AssociadoJaPossuiLancamentoEm(LancamentoBase lancamentoBase)
        {
            var countLancamentos = lancamentosBase.FindAll(
                new LancamentoPorAssociado(lancamentoBase.Associado) &
                new LancamentoPorCentroDeCusto(lancamentoBase.CentroDeCustoLancamento)
                ).Count();

            return  countLancamentos > 0;
        }

        public void Pagar(IEnumerable<LancamentoBase> lancamentosBase, int numeroRecibo)
        {
            foreach (var lancamentoBase in lancamentosBase)
            {
                Pagar(lancamentoBase, numeroRecibo);
            }
        }


        public void Pagar(LancamentoBase lancamentoBase, int numeroRecibo)
        {
            if (lancamentoBase.LancamentoCancelado || 
                LancamentoJaEstaPago(lancamentoBase))
                throw new InvalidOperationException("Não e possível pagar uma mensalidade cancelada, ou já está paga.");

            lancamentoBase.DataPagamento = DateTime.Now;

            //TODO: Ajustar a Regra de Credito e Debito
            if (lancamentoBase is ICredito)
            {
                var movimentoDeCaixa = MovimentoDeCaixaFactory.CriarMovimentoDeCaixaCredito(lancamentoBase, numeroRecibo);
                movimentoDeCaixaService.InserirMovimento(movimentoDeCaixa);
            }
            else if(lancamentoBase is IDebito)
            {
                var movimentoDeCaixa = MovimentoDeCaixaFactory.CriarMovimentoDeCaixaDebito(lancamentoBase);
                movimentoDeCaixaService.InserirMovimento(movimentoDeCaixa);
            }
            else
            {
                throw new InvalidOperationException("Não foi possivel realizar o lançamento porque o objeto passado não é de Debito nem de Credito");
            }

            lancamentosBase.Add(lancamentoBase);
        }

        private bool LancamentoJaEstaPago(LancamentoBase lancamentoBase)
        {
            if(lancamentoBase.DataPagamento != null || 
                movimentoDeCaixaService.RecuperarMovimentoDeCaixaPor(lancamentoBase).Count() > 0)
            {
                return true;
            }
            return false;
        }

    }
}
