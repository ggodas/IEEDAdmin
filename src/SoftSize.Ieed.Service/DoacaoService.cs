using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Service
{
    public class DoacaoService
    {
        private IRepository<LancamentoDoacao> doacoes;
        public DoacaoService(IRepository<LancamentoDoacao> doacoes)
        {
            this.doacoes = doacoes;
        }
        public void IncluirDoacao(LancamentoDoacao lancamentoDoacao)
        {
            doacoes.Add(lancamentoDoacao);
        }
    }
}
