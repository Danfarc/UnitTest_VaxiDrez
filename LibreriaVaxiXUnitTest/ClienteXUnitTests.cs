using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{

    public class ClienteXUnitTests
    {
        private Cliente _cliente;

        public ClienteXUnitTests()
        {
            _cliente = new Cliente();
        }

        [Fact]
        public void CrearNombreCompleto_InputNombreApellido_ReturNombreCompleto()
        {
            //arrange
            //Cliente cliente = new();

            //act
            _cliente.CrearNombreCompleto("Vaxi", "Drez");


            //assert
            Assert.Equal("Vaxi Drez",_cliente.ClientNombre);
            Assert.Contains("Drez",_cliente.ClientNombre);
            Assert.StartsWith("Vaxi",_cliente.ClientNombre);
            Assert.EndsWith("Drez",_cliente.ClientNombre);

        }


        [Fact]
        public void ClientNombre_NoValues_ReturNull()
        {
            //Cliente cliente = new();
            Assert.Null(_cliente.ClientNombre);
        }

        [Fact]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {
            int descuento = _cliente.Descuento;
            Assert.InRange(descuento,5,24);
        }

        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            _cliente.CrearNombreCompleto("Vaxi", "");
            Assert.NotNull(_cliente.ClientNombre);
            Assert.False(string.IsNullOrEmpty(_cliente.ClientNombre));
        }

        [Fact]
        public void ClientNombre_InputNombreEnBlanco_ThrowsException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Drez"));
            Assert.Equal("El nombre esta en blanco", exceptionDetalle.Message);
            Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Drez"));
 
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            _cliente.OrderTotal = 150;
            var resultado = _cliente.GetClienteDetalle();
            Assert.IsType<ClienteBasico>(resultado);
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMasde500TotalOrder_ReturnsClientePremiun()
        {
            _cliente.OrderTotal = 700;
            var resultado = _cliente.GetClienteDetalle();
            Assert.IsType<ClientePremium>(resultado);
        }
    }
}
