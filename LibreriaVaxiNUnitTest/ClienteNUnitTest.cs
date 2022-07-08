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

            Assert.Multiple(() =>
            {
                //assert
                Assert.That(_cliente.ClientNombre, Is.EqualTo("Vaxi Drez"));
                Assert.AreEqual(_cliente.ClientNombre, "Vaxi Drez");
                Assert.That(_cliente.ClientNombre, Does.Contain("Drez"));
                Assert.That(_cliente.ClientNombre, Does.Contain("drez").IgnoreCase);
                Assert.That(_cliente.ClientNombre, Does.StartWith("Vaxi"));
                Assert.That(_cliente.ClientNombre, Does.EndWith("Drez"));

            });
        }
            

        [Test]
        public void ClientNombre_NoValues_ReturNull()
        {
            //Cliente cliente = new();
            Assert.IsNull(_cliente.ClientNombre);
        }

        [Test]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {
            int descuento = _cliente.Descuento;
            Assert.That(descuento, Is.InRange(5, 24));
        }

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            _cliente.CrearNombreCompleto("Vaxi", "");
            Assert.IsNotNull(_cliente.ClientNombre);
            Assert.IsFalse(string.IsNullOrEmpty(_cliente.ClientNombre));
        }

        [Test]
        public void ClientNombre_InputNombreEnBlanco_ThrowsException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Drez"));
            Assert.AreEqual("El nombre esta en blanco", exceptionDetalle.Message);
            Assert.That(() => 
            _cliente.CrearNombreCompleto("", "Drez"), Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco")
            );

            Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Drez"));
            Assert.That(() =>
            _cliente.CrearNombreCompleto("", "Drez"), Throws.ArgumentException
            );
        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            _cliente.OrderTotal = 150;
            var resultado = _cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMasde500TotalOrder_ReturnsClientePremiun()
        {
            _cliente.OrderTotal = 700;
            var resultado = _cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClientePremium>());
        }
    }
}
