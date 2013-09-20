using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels.ServiceInterfaces
{
    public interface ILancamentoServiceApplication
    {
        IEnumerable<LancamentoModel> ListarMensalidadesDo(AssociadoModel associadoModel);
        LancamentoModel ListarMensalidadesDoAssociadoEDependentes(AssociadoModel associado);
        IEnumerable<LancamentoModel> ListarLancamentosDespesa();
        void IncluirMensalidade(LancamentoModel lancamentoModel);
        void IncluirDoacao(LancamentoModel mensalidadeModel);
        void IncluirMensalidadesParaUsuariosAtivos(LancamentoMensalidadeLoteViewModel dataLancamentoMensalidadeModel);

        LancamentoMensalidadeLoteViewModel CriarlancamentoMensalidadeLoteViewModel(
            LancamentoMensalidadeLoteViewModel lancamentoMensalidadeLoteViewModel);
        LancamentoDespesaModel CriarLancamentoDespesaModel(LancamentoDespesaModel lancamentoDespesaModel);
        void IncluirLancamentoDespesa(LancamentoDespesaModel lancamentoDespesaModel);
        void IncluirCerimonia(LancamentoCerimoniaModel cerimoniaModel);
        LancamentoCerimoniaModel CriarLancamentoCerimoniaModel(LancamentoCerimoniaModel lancamentoCerimoniaModel);
        PagementosSelecionadosModel RecuperarLancamentosPor(PagamentoModel pagamentoModel);
        void Pagar(PagamentoModel pagamentoModel);
        LancamentoModel CriarLancamentoMensalidadeModel(LancamentoModel mensalidadeModel, Guid idAssociado);
    }
}
