using System;
using System.Collections.Generic;
using SoftSize.Ieed.Model.FinanceiroModel.Caixa;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Service.Specifications;
using SoftSize.Infrastructure;
using System.Linq;

namespace SoftSize.Ieed.Service
{
    public class MovimentoDeCaixaService : IMovimentoDeCaixaService
    {
        private IRepository<MovimentoDeCaixa, Guid> movimentosDeCaixa;
        public MovimentoDeCaixaService(IRepository<MovimentoDeCaixa, Guid> movimentosDeCaixa)
        {
            this.movimentosDeCaixa = movimentosDeCaixa;
        }

     
        public void InserirMovimento(MovimentoDeCaixa movimentoDeCaixa)
        {
            movimentoDeCaixa.CalcularTotal(RecuperarTotalDaUltimaMovimentacaoDeCaixa());
            movimentosDeCaixa.Add(movimentoDeCaixa);
        }

        public IEnumerable<MovimentoDeCaixa> RecuperarMovimentoDeCaixaPor(LancamentoBase lancamentoBase)
        {
            return movimentosDeCaixa.FindAll(new MovimentoDeCaixaPor(lancamentoBase));
        }

        private decimal RecuperarTotalDaUltimaMovimentacaoDeCaixa()
        {
            if (movimentosDeCaixa.Count == 0)
                return 0;

            var dataUltimoLancamento = movimentosDeCaixa.Max(m => m.DataDaMovimentacao);
            return movimentosDeCaixa.First(m => m.DataDaMovimentacao == dataUltimoLancamento).Total;

        }

    }
}
