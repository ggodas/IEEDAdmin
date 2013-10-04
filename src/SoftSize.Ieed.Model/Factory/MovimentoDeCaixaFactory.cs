using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftSize.Ieed.Model.FinanceiroModel.Caixa;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Model.Factory
{
    public static class MovimentoDeCaixaFactory
    {
        public static MovimentoDeCaixaCredito CriarMovimentoDeCaixaCredito(LancamentoBase lancamentoBase, int numeroRecibo)
        {
            return new MovimentoDeCaixaCredito(lancamentoBase)
                       {
                           DataDaMovimentacao = DateTime.Now,
                           Credito = lancamentoBase.Valor,
                           NumeroDocumento = numeroRecibo
                       };
        }

        public static MovimentoDeCaixaDebito CriarMovimentoDeCaixaDebito(LancamentoBase lancamentoBase)
        {
            return new MovimentoDeCaixaDebito(lancamentoBase)
            {
                DataDaMovimentacao = DateTime.Now,
                Debito = lancamentoBase.Valor
            };
        }
    }
}
