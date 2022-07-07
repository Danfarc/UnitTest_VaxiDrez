using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        private Cliente _cliente;

        [SetUp]
        public void Setup()
        {
            _cliente = new Cliente();
        }

        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturNombreCompleto()
        {
            //arrange
            //Cliente cliente = new();

            //act
            _cliente.CrearNombreCompleto("Vaxi", "Drez");

            //assert
            Assert.That(_cliente.ClientNombre, Is.EqualTo("Vaxi Drez"));
            Assert.AreEqual(_cliente.ClientNombre, "Vaxi Drez");
            Assert.That(_cliente.ClientNombre, Does.Contain("Drez"));
            Assert.That(_cliente.ClientNombre, Does.Contain("drez").IgnoreCase);
            Assert.That(_cliente.ClientNombre, Does.StartWith("Vaxi"));
            Assert.That(_cliente.ClientNombre, Does.EndWith("Drez"));
        }

        [Test]
        public void ClientNombre_NoValues_ReturNull()
        {
            //Cliente cliente = new();
            Assert.IsNull(_cliente.ClientNombre);
        }
    }
}
