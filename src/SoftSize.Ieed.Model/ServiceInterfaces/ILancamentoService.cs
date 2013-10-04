using System;
using System.Collections.Generic;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Model.ServiceInterfaces
{
    public interface ILancamentoService
    {
        void IncluirLancamento(LancamentoBase lancamentoBase);
        void IncluirLancamentoSemValidacao(LancamentoBase lancamento);
        void GerarMensalidadesEmLote(CentroDeCustoLancamento centroDeCustoLancamento);
        IEnumerable<LancamentoBase> ListarLancamentosDo(Associado associado);
        IEnumerable<LancamentoBase> ListarLancamentosPor(Guid[] ids);
        IEnumerable<LancamentoDespesa> ListarLancamentosDespesa();
        void Pagar(LancamentoBase lancamentoBase, int numeroRecibo);
        void Pagar(IEnumerable<LancamentoBase> lancamentosBase, int numeroRecibo);
    }
}
