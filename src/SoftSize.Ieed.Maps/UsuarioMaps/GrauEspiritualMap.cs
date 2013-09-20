using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Maps.UsuarioMaps
{
    public class GrauEspiritualMap : ClassMap<GrauEspiritual>
    {
        public GrauEspiritualMap()
        {
            Id(m => m.Id).GeneratedBy.GuidComb();
            Version(m => m.Version);
            Map(m => m.Grau);

            Table("GrauEspiritual");
        }
    }
}

