using ClienteCRUDLogica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ClienteCRUDTest
{
    [TestClass]
    public class DadosBasicosTest
    {
        [TestMethod]
        public void SexoCadastrado()
        {
            var logica = new SexoLogica();
            var dados = logica.GetAll();

            Assert.IsTrue(dados.Count() > 0);
        }

        [TestMethod]
        public void EstadoCivilCadastrado()
        {
            var logica = new EstadoCivilLogica();
            var dados = logica.GetAll();

            Assert.IsTrue(dados.Count() > 0);
        }

        [TestMethod]
        public void OrgaoExpedicaoCadastrado()
        {
            var logica = new OrgaoExpedicaoLogica();
            var dados = logica.GetAll();

            Assert.IsTrue(dados.Count() > 0);
        }
    }
}
