using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    public class ProductoXUnitTests
    {
        [Fact]
        public void GetPrecio_PremiumCliente_ReturnsPrecio80()
        {

            Producto producto = new Producto()
            {
                Precio = 50
            };

            var resultado = producto.GetPrecio(new Cliente { IsPremium = true });
            Assert.Equal(40, resultado);
        }

        [Fact]
        public void GetPrecio_PremiumClienteMoq_ReturnsPrecio80()
        {

            Producto producto = new Producto()
            {
                Precio = 50
            };
            var cliente = new Mock<ICliente>();
            cliente.Setup(s => s.IsPremium).Returns(true);

            var resultado = producto.GetPrecio(cliente.Object);
            Assert.Equal(40,resultado);
        }
    }
}
