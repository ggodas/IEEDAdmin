using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Maps.LancamentoMaps
{
    public class CentroDeCustoLancamentoMap : ClassMap<CentroDeCustoLancamento>
    {
        public CentroDeCustoLancamentoMap()
        {
            Id(m => m.Id).GeneratedBy.GuidComb();
            Version(m => m.Version);

            Map(m => m.Descricao).Length(100);
            Map(m => m.Data);
            HasMany(m => m.LancamentosBase);

            Table("CentroDeCustoLancamento");

        }
    }
}
