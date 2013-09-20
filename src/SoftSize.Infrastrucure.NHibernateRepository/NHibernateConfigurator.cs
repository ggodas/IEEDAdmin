using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace SoftSize.Infrastrucure.NHibernateRepository
{

    public static class NHConfigurator<T>
    {
        private static readonly Configuration configuration;
        private static readonly ISessionFactory sessionFactory;

        static NHConfigurator()
        {


            configuration = Fluently.Configure()
                .ExposeConfiguration(cfg => cfg.CurrentSessionContext<NHibernate.Context.ThreadStaticSessionContext>())
                .Database(MySQLConfiguration.Standard
                              //.CurrentSessionContext("thread_static")
                              
                              .ConnectionString(
                                  c => c
                                           .FromConnectionStringWithKey("ApplicationServices"))
                              .ShowSql()
                )
                .Mappings(m => m.
                //FluentMappings.AddFromAssembly(Assembly.Load("CTF.Fidelidade.Premmia.Data.Maps"))) 
                FluentMappings.AddFromAssemblyOf<T>())
                .BuildConfiguration();

            //configuration
            //    .SetProperty("expiration", "1000000")
            //    .SetProperty(Environment.UseSecondLevelCache, "true")
            //    .SetProperty(Environment.UseQueryCache, "true")
            //    //.Cache(c => c.Provider<SysCacheProvider>())
            //    //.EntityCache<Usuario>(c =>
            //    //                          {
            //    //                              c.Collection(m => m.PerfisDeAcesso,
            //    //                                           s =>
            //    //                                               {
            //    //                                                   s.Strategy = EntityCacheUsage.Readonly;
            //    //                                                   s.RegionName = "hourly";
            //    //                                               });
            //    //                              c.Collection(m => m.Acessos,
            //    //                                           s =>
            //    //                                               {
            //    //                                                   s.Strategy = EntityCacheUsage.Readonly;
            //    //                                                   s.RegionName = "hourly";
            //    //                                               });

            //    //                              c.Strategy = EntityCacheUsage.Readonly;
            //    //                              c.RegionName = "hourly";
            //    //                          })
            //    //.EntityCache<Acesso>(c =>
            //    //                         {
            //    //                             c.Strategy =
            //    //                                 EntityCacheUsage.Readonly;
            //    //                             c.RegionName = "hourly";
            //    //                         })
            //    .EntityCache<PerfilDeAcesso>(c =>
            //                                     {
            //                                         c.Collection(m => m.Permissoes,
            //                                                      s =>
            //                                                          {
            //                                                              s.Strategy =
            //                                                                  EntityCacheUsage.
            //                                                                      Readonly;
            //                                                              s.RegionName =
            //                                                                  "hourly";
            //                                                          });
            //                                         c.Strategy = EntityCacheUsage.Readonly;
            //                                         c.RegionName = "hourly";
            //                                     })
            //    .EntityCache<Permissao>(c =>
            //                                {
            //                                    c.Collection(m => m.SubPermissoes,
            //                                                 s =>
            //                                                     {
            //                                                         s.Strategy = EntityCacheUsage.Readonly;
            //                                                         s.RegionName = "hourly";
            //                                                     });
            //                                    c.Strategy = EntityCacheUsage.Readonly;
            //                                    c.RegionName = "hourly";
            //                                })
            //    .EntityCache<Sistema>(c =>
            //                              {
            //                                  c.Strategy = EntityCacheUsage.Readonly;
            //                                  c.RegionName = "hourly";
            //                              })
            //    .EntityCache<PermissaoResource>(c =>
            //                                        {
            //                                            c.Strategy =
            //                                                EntityCacheUsage.
            //                                                    Readonly;
            //                                            c.RegionName =
            //                                                "hourly";
            //                                        })
            //    .EntityCache<PermissaoTemplate>(c =>
            //                                        {
            //                                            c.Strategy =
            //                                                EntityCacheUsage.Readonly;
            //                                            c.RegionName = "hourly";
            //                                        });

            //.EntityCache<InformacaoDaFuncionalidade>(c =>
            //                                             {
            //                                                 c.Strategy = EntityCacheUsage.Readonly;
            //                                                 c.RegionName = "hourly";
            //                                             });





            sessionFactory = configuration.BuildSessionFactory();
        }

        public static Configuration Configuration
        {
            get
            {
                return configuration;
            }
        }



        public static ISessionFactory SessionFactory
        {
            get
            {
                return sessionFactory;
            }
        }
    }
}
