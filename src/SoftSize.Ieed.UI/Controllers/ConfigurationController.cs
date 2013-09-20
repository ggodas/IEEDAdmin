using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SoftSize.Ieed.Maps.UsuarioMaps;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.UI.Controllers
{
    public class ConfigurationController : Controller
    {
        private Configuration nhConfig;

        public ActionResult Index()
        {
            nhConfig = Fluently.Configure()
               .Database(MySQLConfiguration.Standard
                  .ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString()))
                   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
               .BuildConfiguration();





            nhConfig.AddAssembly(typeof(UsuarioMap).Assembly);
            var sessionFactory = nhConfig.BuildSessionFactory();

            var schemaExport = new SchemaExport(nhConfig);
            schemaExport.Create(false, true);





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





            var perfilDeAcesso = new PerfilDeAcesso() { Nome = "Administrador", Ativo = true };
            //session.SaveOrUpdate(perfilDeAcesso);
            //session.Flush();

            //var perfil = session.Get<PerfilDeAcesso>(perfilDeAcesso.Id);

            perfilDeAcesso.IncluirSubPerfil(new PerfilDeAcesso() { Nome = "Tesouraria", Ativo = true });
            perfilDeAcesso.IncluirSubPerfil(new PerfilDeAcesso() { Nome = "Associado", Ativo = true });

            session.SaveOrUpdate(perfilDeAcesso);
            session.Flush();

            var permissao = new Permissao() { NomeDaFuncionalidade = "Associado", NomePermissao = "Associado" };
            permissao.IncluirSubPermissao(new Permissao() { NomeDaFuncionalidade = "ListaAssociado", NomePermissao = "Lista" });
            permissao.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "CadastroAssociado", NomePermissao = "Cadastro" });
            permissao.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "AlteracaoAssociado", NomePermissao = "Alteração" });
            session.SaveOrUpdate(permissao);

            var permissaoMensalidades = new Permissao() { NomeDaFuncionalidade = "Financeiro", NomePermissao = "Financeiro" };
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "NovoLancamentoFinanceiro", NomePermissao = "Novo Lançamento" });
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "ConsultaFinanceiro", NomePermissao = "Consulta" });


            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "LancamentoDespesa", NomePermissao = "Lançamento de Despesa" });
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "LancamentoDoacao", NomePermissao = "Lançamento de Doação" });
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "LancamentoMensalidadeLote", NomePermissao = "Lançamento de Mensalidades em Lote" });
            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "LancamentoDeCerimonia", NomePermissao = "Lançamento de Cerimonia(para o Associado)" });

            permissaoMensalidades.IncluirSubPermissao(new Permissao { NomeDaFuncionalidade = "NovoCentroDeCusto", NomePermissao = "Novo Centro de Custo" });

            session.SaveOrUpdate(permissaoMensalidades);

            session.Flush();


            return RedirectToAction("Index", "Home");
        }

    }
}
