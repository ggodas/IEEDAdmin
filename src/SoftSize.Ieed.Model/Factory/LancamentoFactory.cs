using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftSize.Ieed.Model.FinanceiroModel;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Model.Factory
{
    public static class LancamentoFactory
    {
        public static LancamentoCerimonia CriarLancamentoDeCerimonia(Associado associado, CentroDeCustoLancamento centroDeCustoLancamento)
        {
            //if (associado.IsValid)
            //{
                return new LancamentoCerimonia(associado, centroDeCustoLancamento);
            //}
            //return null;
        }

        public static LancamentoMensalidade CriarLancamentoDeMensalidade(Associado associado, CentroDeCustoLancamento centroDeCustoLancamento)
        {
            if(associado.Id == new Guid())
                throw new InvalidOperationException("Objeto associado está em modo transiente, não é possível gerar um a mensalidade.");

            if(associado.MensalidadeCategoria == null || associado.MensalidadeCategoria.Valor == 0)
                throw new InvalidOperationException("Objeto associado não possui uma categoria de Mensalidade.");

            return new LancamentoMensalidade(associado, centroDeCustoLancamento);
        }

        public static LancamentoDoacao CriarLancamentoDeDoacao(Associado associado)
        {
            throw new NotImplementedException("Implementar centro de custo");
            if (associado.Id == new Guid())
                throw new InvalidOperationException("Objeto associado está em modo transiente, não é possível gerar uma doação.");

                return new LancamentoDoacao(associado, null);
        }

    }
}
