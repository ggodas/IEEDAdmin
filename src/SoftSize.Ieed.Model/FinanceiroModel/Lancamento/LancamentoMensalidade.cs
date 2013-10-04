using System;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Model.FinanceiroModel.Lancamento
{
    public class LancamentoMensalidade : LancamentoBase, ICredito
    {
        protected LancamentoMensalidade():base(null)
        {
            
        }
        internal LancamentoMensalidade(Associado associado, CentroDeCustoLancamento centroDeCustoLancamento): base(centroDeCustoLancamento)
        {
            this.Associado = associado;
            this.Valor = associado.MensalidadeCategoria.Valor;
        }
    }
}
