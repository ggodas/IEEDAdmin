using CTF.Fidelidade.Premmia.Domain.SSODomain;
using FluentNHibernate.Mapping;

namespace SoftSize.Ieed.Maps
{
    public class PerfilDeAcessoMap : ClassMap<PerfilDeAcesso>
    {
        public PerfilDeAcessoMap()
        {
            Id(U => U.Id).GeneratedBy.GuidComb();

            Version(U => U.Version);

            Map(p => p.Nome);
            Map(p => p.Ativo);
            Map(p => p.EPerfilPadrao);

            HasManyToMany(p => p.Permissoes)
                .AsBag()
                .Table("PerfilPermissao")
                .ChildKeyColumns.Add("IdPermissao")
                .ParentKeyColumn("IdPerfil")
                .Inverse()
                .LazyLoad();
            //.Cache.ReadWrite();


            HasMany(p => p.SubPerfis)
                .Table("PerfilPermissao")
                .KeyColumn("IdPerfilPai")
                .AsBag().Cascade.All();


            References(p => p.PerfilDeAcessoGerador).Column("IdPerfilPai").LazyLoad().NotFound.Ignore();

            Table("Perfil");
        }

    }
}
