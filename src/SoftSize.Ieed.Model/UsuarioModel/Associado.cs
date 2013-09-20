using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using SoftSize.Ieed.Model.FinanceiroModel;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Model.UsuarioModel
{
    public class Associado : Usuario
    {
        public virtual AssociadoDetalhe AssociadoDetalhe { get; set; }
        //public virtual string NomeCompleto { get; set; }

        public virtual Associado DependenteDe { get; set; }
        public virtual IList<Associado> Dependentes { get; set; }
        private IList<LancamentoBase> lancamentos;
        public virtual IEnumerable<LancamentoBase> Lancamentos
        {
            get { return lancamentos; }
        }

        //private IList<LancamentoCerimonia> cerimonias;
        //public virtual IEnumerable<LancamentoCerimonia> Cerimonias
        //{
        //    get { return cerimonias; }
        //}


        public virtual Endereco EnderecoCorrespondencia { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual GrauEspiritual GrauEspiritual { get; set; }
        public virtual MensalidadeCategoria MensalidadeCategoria { get; set; }

        public virtual void AdicionarLancamento(LancamentoBase lancamentoBase)
        {
            lancamentos.Add(lancamentoBase);
        }


        public virtual IEnumerable<LancamentoBase> LancamentosDoAssociadoEDependentes()
        {
            var lancamentosUsuario = new List<LancamentoBase>();
            Action<Associado> recuperarLancamentosRecursivo = null;
            
            recuperarLancamentosRecursivo = associado =>
                                                {
                                                    lancamentosUsuario.AddRange(associado.Lancamentos.Where(m => m.DataPagamento == null && !m.LancamentoCancelado));

                                                    foreach (var dependente in associado.Dependentes)
                                                    {
                                                        recuperarLancamentosRecursivo(dependente);
                                                    }
                                                };

            recuperarLancamentosRecursivo(this);
            return lancamentosUsuario;
        }

        //public virtual IEnumerable<LancamentoCerimonia> RecuperarLancamentosDeCerimoniaDoAssociadoEDependentes()
        //{
        //    var lancamentos = new List<LancamentoCerimonia>();
        //    Action<Associado> recuperarLancamentosRecursivo = null;

        //    recuperarLancamentosRecursivo = associado =>
        //                                        {
        //                                            lancamentos.AddRange(associado.Cerimonias.Where(m => m.DataPagamento == null && !m.LancamentoCancelado));

        //                                            foreach (var dependente in associado.Dependentes)
        //                                            {
        //                                                recuperarLancamentosRecursivo(dependente);
        //                                            }
        //                                        };

        //    recuperarLancamentosRecursivo(this);
        //    return lancamentos;
        //}



    }
}
