using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Maps.LancamentoMaps
{
    public class MensalidadeCategoriaMap : ClassMap<MensalidadeCategoria>
    {
        public MensalidadeCategoriaMap()
        {
            Id(m => m.Id).GeneratedBy.GuidComb();
            Version(m => m.Version);

            Map(m => m.Descricao).Length(100);
            Map(m => m.Valor);

            Table("MensalidadeCategoria");
        }
    }
}
