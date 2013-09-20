using System.Collections.Generic;
using SoftSize.Ieed.Model.FinanceiroModel.Caixa;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Model.ServiceInterfaces
{
    public interface IMovimentoDeCaixaService
    {
        void InserirMovimento(MovimentoDeCaixa movimentoDeCaixa);
        IEnumerable<MovimentoDeCaixa> RecuperarMovimentoDeCaixaPor(LancamentoBase lancamentoBase);

    }
}