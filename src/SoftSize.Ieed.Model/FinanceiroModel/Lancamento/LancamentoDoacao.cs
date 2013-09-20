using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Model.FinanceiroModel.Lancamento
{
    public class LancamentoDoacao : LancamentoBase, ICredito
    {
        protected LancamentoDoacao(): base(null)
        {
            
        }
        internal LancamentoDoacao(Associado associado, CentroDeCustoLancamento centroDeCustoLancamento) : base(centroDeCustoLancamento)
        {
            this.Associado = associado;
        }
    }
}
