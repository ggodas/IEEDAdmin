using System;
using System.Linq;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SoftSize.Ieed.Maps.UsuarioMaps;
using SoftSize.Ieed.Model.Factory;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Tests
{
    [TestClass]
    public class NHibernateTest
    {
        private Configuration nhConfig;

        [TestInitialize]
        public void SetUp()
        {
            //nhConfig = Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2005
            //    //.ConnectionString(@"data source=ult4augxsk.database.windows.net;Initial Catalog=IEED;User Id=georgegodas;Password=G30rg3g0d4s")
            //    //.ConnectionString(@"data source=NBWNVS-GEORGE;Initial Catalog=IEED;User Id=sa;Password=m1n124")
            //    .ConnectionString(@"data source=.\SQLEXPRESS;Initial Catalog=IEED;User Id=sa;Password=sa")
            //                  .Cache(c => c
            //                                  .UseQueryCache()
            //                                  .ProviderClass<HashtableCacheProvider>())
            //                  .ShowSql())
            //    .Mappings(m => m
            //                       .FluentMappings.AddFromAssemblyOf<UsuarioMap>()).BuildConfiguration();
            ////var nhConfig = new Configuration().Configure(@"C:\Projetos\SoftSize.Ieed\Tests\SoftSize.Ieed.Tests\hibernate.cfg.xml");

        }

        [TestMethod]
        public void CanCreateDataBase()
        {
            nhConfig.AddAssembly(typeof(UsuarioMap).Assembly);
            var sessionFactory = nhConfig.BuildSessionFactory();

            var schemaExport = new SchemaExport(nhConfig);
            schemaExport.Create(false, true);

        }

        [TestMethod]
        public void CanCreateGrauEspiritual()
        {
            var session = nhConfig.BuildSessionFactory().OpenSession();


            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Oração Dominical" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Mocidade" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Associado" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Irmão de Aureola" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Aspirante" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Sac. Grau 4" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Sac. Grau 3" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Sac. Grau 2" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Sac. Grau 1" });
            session.SaveOrUpdate(new GrauEspiritual() { Grau = "Rev. IEED" });
            session.Flush();
        }

        [TestMethod]
        public void CanCreatePerfis()
        {
            var session = nhConfig.BuildSessionFactory().OpenSession();

            var perfilDeAcesso = new PerfilDeAcesso() {Nome = "Administrador", Ativo = true};
            //session.SaveOrUpdate(perfilDeAcesso);
            //session.Flush();

            //var perfil = session.Get<PerfilDeAcesso>(perfilDeAcesso.Id);

            perfilDeAcesso.IncluirSubPerfil(new PerfilDeAcesso() { Nome = "Tesouraria", Ativo = true });
            perfilDeAcesso.IncluirSubPerfil(new PerfilDeAcesso() { Nome = "Associado", Ativo = true });
            perfilDeAcesso.IncluirSubPerfil(new PerfilDeAcesso() { Nome = "Anonimo", Ativo = true, EPerfilPadrao = true });

            session.SaveOrUpdate(perfilDeAcesso);
            session.Flush();

        }

        [TestMethod]
        public void CanCreatePermissoes()
        {
            var session = nhConfig.BuildSessionFactory().OpenSession();

            var permissao = new Permissao() { NomeDaFuncionalidade = "Associado",  NomePermissao= "Associado" };
            permissao.IncluirSubPermissao(new Permissao() { NomeDaFuncionalidade = "ListaAssociado", NomePermissao = "Lista" });
            permissao.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "CadastroAssociado", NomePermissao = "Cadastro" });
            permissao.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "AlteracaoAssociado", NomePermissao = "Alteração" });
            session.SaveOrUpdate(permissao);

            var permissaoMensalidades = new Permissao() { NomeDaFuncionalidade = "Financeiro", NomePermissao = "Financeiro" };
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "NovoLancamentoFinanceiro", NomePermissao = "Novo Lançamento" });
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "ConsultaFinanceiro", NomePermissao = "Consulta" });
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "LancamentoMensalidadeLote", NomePermissao = "Lançamento de Mensalidade em Lote" });
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "Pagar", NomePermissao = "Pagar Lançamentos" });
            session.SaveOrUpdate(permissaoMensalidades);
          
            session.Flush();


        }

        [TestMethod]
        public void CanCreateAssociado()
        {

            //Associado associado = new Associado()
            //                          {
            //                              Endereco =
            //                                  new Endereco { Cep = "055555555", Logradouro = "Rua Não Sei o Nome"},
            //                              Nome = "Bruno da Silva Rangel",
            //                              Senha = "123456"
            //                          };


            //Associado associadoDependente = new Associado()
            //{
            //    Endereco =
            //        new Endereco { Cep = "05327050", Logradouro = "Rua Adelina Gasparian", Number = "141" },
            //    Nome = "Abigail Marinho de Oliveira Godas",
            //    Senha = "m1n124",
            //    UsuarioDetalhes = new UsuarioDetalhes { Rg = "000000000" }
            //};

            //            associadoDependente.DependenteDe = associado;

            //var session = nhConfig.BuildSessionFactory().OpenSession();

            //session.SaveOrUpdate(associado);
            ////session.SaveOrUpdate(associadoDependente);
            //session.Flush();
        }


        [TestMethod]
        public void CanCreateLancamento()
        {
            //var session = nhConfig.BuildSessionFactory().OpenSession();
            //var result = session.Get<Associado>(new Guid("AE0A3484-193C-4520-A850-9EAF0114E077"));

            //var doacao = LancamentoFactory.CriarLancamentoDeDoacao(result);

            //doacao.DataLancamento = DateTime.Now;
            //doacao.DataPagamento = DateTime.Now;
            //doacao.Valor = 110.50m;
            //result.AdicionarMensalidade(doacao);

            //var mensalidade = LancamentoFactory.CriarLancamentoDeMensalidade(result);

            //mensalidade.DataLancamento = DateTime.Now;
            //mensalidade.DataPagamento = DateTime.Now.AddDays(5);
            //// mensalidade.DataVencimento = DateTime.Now.AddDays(6);
            //result.AdicionarMensalidade(mensalidade);


            //var cerimonia = LancamentoFactory.CriarLancamentoDeCerimonia(result);

            //cerimonia.DataLancamento = DateTime.Now;
            //cerimonia.DataPagamento = DateTime.Now.AddDays(5);
            //result.AdicionarMensalidade(cerimonia);





            //session.SaveOrUpdate(result);
            //session.Flush();

        }


        [TestMethod]
        public void CanCreateDependentOfDependent()
        {
            //var session = nhConfig.BuildSessionFactory().OpenSession();
            //var result = session.Get<Associado>(new Guid("47145977-7CF6-46B3-81DB-9EAF00F8D697"));

            //Associado associadoDependente = new Associado()
            //{
            //    Endereco =
            //        new Endereco { Cep = "05327050", Logradouro = "Rua Adelina Gasparian"},
            //    Nome = "Julia Marinho Krajan Godas",
            //    UsuarioDetalhe = new "m1n124"
            //};

            //associadoDependente.DependenteDe = result;

            //session.SaveOrUpdate(associadoDependente);
            //session.Flush();
        }

        public void CanCreateMoviemnto()
        {
        }

        [TestMethod]
        public void CanRetrieveAssociado()
        {
            //var session = nhConfig.BuildSessionFactory().OpenSession();
            //var result = session.Get<Associado>(new Guid("AE0A3484-193C-4520-A850-9EAF0114E077"));

            //var lista = result.RecuperarLancamentosDoAssociadoEDependentes().ToList();

        }
    }
}
