using CTF.Fidelidade.Premmia.Domain.SSODomain;
using FluentNHibernate.Mapping;

namespace SoftSize.Ieed.Maps
{
    public class PermissaoMap : ClassMap<Permissao>
    {
        public PermissaoMap()
        {

            Id(k => k.Id).GeneratedBy.GuidComb();
            Version(U => U.Version);



            Map(p => p.NomePermissao);
            Map(p => p.NomeDaFuncionalidade);

            References(p => p.PermissaoPai)
                .Column("IdPermissaoPai").LazyLoad();

            HasMany(p => p.SubPermissoes)
                .KeyColumn("IdPermissaoPai")
                .NotFound.Ignore()
                .LazyLoad()
                .Cascade.All();

            Table("Permissao");
        }

    }
}
