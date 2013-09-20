using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Maps.UsuarioMaps
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(m => m.Id).GeneratedBy.GuidComb();
            Version(m => m.Version);

            Map(m => m.Nome);
            Map(m => m.NomeDeUsuario);
            Map(m => m.Senha);
            Map(m => m.Email);
            Map(m => m.Ativo);

            HasManyToMany(p => p.PerfisDeAcesso)
             .Table("LoginPerfil")
             .ChildKeyColumn("IdPerfil")
             .ParentKeyColumn("IdLogin")
             .Cascade.All()
             .LazyLoad();

            
            Table("Usuario");
        }
    }
}

