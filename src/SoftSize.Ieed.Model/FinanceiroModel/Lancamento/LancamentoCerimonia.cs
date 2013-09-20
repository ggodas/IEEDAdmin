using System;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Model.FinanceiroModel.Lancamento
{
    public class LancamentoCerimonia : LancamentoBase, ICredito
    {
        protected LancamentoCerimonia(): base(null)
        {
        }
        public LancamentoCerimonia(Associado associado, CentroDeCustoLancamento centroDeCustoLancamento) : base(centroDeCustoLancamento)
        {
            Associado = associado;
        }
    }
}
