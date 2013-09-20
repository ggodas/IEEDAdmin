using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Maps.UsuarioMaps
{

    public class AssociadoMap : SubclassMap<Associado>
    {
        public AssociadoMap()
        {

            Component(
                m => m.AssociadoDetalhe,
                m =>
                    {
                        m.Map(x => x.DataNascimento);
                        m.Map(x => x.Nascionalidade);
                        m.Map(x => x.NomeMae);
                        m.Map(x => x.NomePai);
                        m.Map(x => x.GrauDeInstrucao);
                        m.Map(x => x.EstadoCivil);
                        m.Map(x => x.DocumentoTipo);
                        m.Map(x => x.DocumentoNumero);
                        m.Map(x => x.DocumentoDataEmissao);
                        m.Map(x => x.CPF);
                        m.Map(x => x.Observacoes);
                        m.Map(x => x.DataDoRequerimento);
                        m.Map(x => x.DataDeAprovacaoDiretoria);
                        m.Map(x => x.Profissao);
                    }
                );

            Component(m =>
                      m.EnderecoCorrespondencia,
                      m =>
                          {
                              m.Map(x => x.Logradouro, "LogradouroCorrespondencia");
                              m.Map(x => x.Cep, "CepCorrespondencia");
                          });
            Component(m =>
                      m.Endereco,
                      m =>
                          {
                              m.Map(x => x.Logradouro);
                              m.Map(x => x.Cep);
                          });

            References(m => m.GrauEspiritual);
            References(m => m.MensalidadeCategoria);

            HasMany(m => m.Lancamentos)
                .KeyColumn("Associado_id")
                .NotFound.Ignore()
                .Cascade.All();

            HasMany(m => m.Dependentes)
                .KeyColumn("DependenteDe_id")
                .NotFound.Ignore()
                .LazyLoad()
                .Cascade.All();

            References(m => m.DependenteDe);
            Table("Associado");
        }
    }
}

