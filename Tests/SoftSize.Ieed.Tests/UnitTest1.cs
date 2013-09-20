using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftSize.Ieed.Model.Factory;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Tests
{
    [TestClass]
    public class FinanceiroModelTests
    {
        [TestMethod]
        public void PodeCriarLancamentoDeCerimonia()
        {
            //var cerimonia = LancamentoFactory.CriarLancamentoDeCerimonia(new Associado());

            //Assert.IsNotNull(cerimonia);
            //Assert.IsNotNull(cerimonia.Associado);

        }

        [TestMethod]
        public void PodeCriarLancamentoDeCerimoniaValida()
        {
            //var cerimonia = LancamentoFactory.CriarLancamentoDeCerimonia(new Associado());

            ////Assert.IsTrue(cerimonia.IsValid);
            ////Assert.IsTrue(cerimonia.Associado.IsValid);
            //Assert.IsFalse(cerimonia.DataLancamento > DateTime.Now, "A data de lançamento não pode ser maior que a atual");
            //Assert.IsFalse(cerimonia.DataPagamento > DateTime.Now, "A data de lançamento não pode ser maior que a atual");
            ////Assert.IsFalse(cerimonia.DataVencimento < DateTime.Now, "A data de lançamento não pode ser maior que a atual");

        }

        [TestMethod]
        public void PodeCriarLancamentoDeMensalidade()
        {
            //var mensalidade = LancamentoFactory.CriarLancamentoDeMensalidade(new Associado());
            

            //Assert.IsNotNull(mensalidade);
            //Assert.IsNotNull(mensalidade.Associado);
            //Assert.IsTrue(mensalidade.IsValid);
            //Assert.IsTrue(mensalidade.Associado.IsValid);
        }

        [TestMethod]
        public void PodeCriarLancamentoDeMensalidadeValida()
        {
        }


    }
}
