using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    [TestFixture]
    public class CuentaBancariaNUnitTests
    {
        private CuentaBancaria _cuenta;


        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Desposito_InputMonto100LoggerFake_ReturnsTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake());
            var resultado = cuentaBancaria.Desposito(100);
            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }

        [Test]
        public void Desposito_InputMonto100Mocking_ReturnsTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();

            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object);
            var resultado = cuentaBancaria.Desposito(100);
            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200,100)]
        [TestCase(200, 150)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            loggerMock.Setup(u => u.LogDataBases(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(u => u.LogBalanceDespuesRetiro(It.IsAny<int>())).Returns(true);
            //loggerMock.Setup(u => u.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Desposito(balance);
            var resultado = cuentaBancaria.Retiro(retiro);
            Assert.IsTrue(resultado);
        }

        [Test]
        [TestCase(200, 300)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            //loggerMock.Setup(u => u.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
            loggerMock.Setup(u => u.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);


            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Desposito(balance);
            var resultado = cuentaBancaria.Retiro(retiro);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue()
        {
            var loogeGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";

            loogeGeneralMock.Setup(u => u.MessageConReturnStr(It.IsAny<string>())).Returns<string>(str => str.ToLower());
            var resultado = loogeGeneralMock.Object.MessageConReturnStr("hoLa Mundo");

            Assert.That(resultado, Is.EqualTo(textoPrueba));

        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingOutPut_ReturnTrue()
        {
            var loogeGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";

            loogeGeneralMock.Setup(u => u.MessageConOutParametroReturnBoolean(It.IsAny<string>(),out textoPrueba)).Returns(true);
            string parametroOut = "";
            var resultado = loogeGeneralMock.Object.MessageConOutParametroReturnBoolean("Vaxi",out parametroOut);

            Assert.IsTrue(resultado);

        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingObjRef_ReturnTrue()
        {
            var loogeGeneralMock = new Mock<ILoggerGeneral>();
            Cliente cliente = new Cliente();
            Cliente clientNoUsado = new Cliente();

            loogeGeneralMock.Setup(u => u.MessageConObjReferenciaReturnBoolean(ref cliente)).Returns(true);

            Assert.IsTrue(loogeGeneralMock.Object.MessageConObjReferenciaReturnBoolean(ref cliente));
            Assert.IsFalse(loogeGeneralMock.Object.MessageConObjReferenciaReturnBoolean(ref clientNoUsado));
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingPropPrioridadTipo_ReturnTrue()
        {
            var loogeGeneralMock = new Mock<ILoggerGeneral>();

            loogeGeneralMock.SetupAllProperties();
            loogeGeneralMock.Setup(u => u.TipoLogger).Returns("warning");
            loogeGeneralMock.Setup(u => u.PrioridadLogger).Returns(10);

            loogeGeneralMock.Object.PrioridadLogger = 100;

            Assert.That(loogeGeneralMock.Object.TipoLogger, Is.EqualTo("warning"));
            Assert.That(loogeGeneralMock.Object.PrioridadLogger, Is.EqualTo(10));

            // CallBack

            string textoTemporal = "Vaxi";

            loogeGeneralMock.Setup(u => u.LogDataBases(It.IsAny<string>()))
                .Returns(true)
                .Callback((string parametro ) => textoTemporal += parametro);

            loogeGeneralMock.Object.LogDataBases("Drez"); //VaxiDrez

            Assert.That(textoTemporal, Is.EqualTo("VaxiDrez"));
        }

        [Test]
        public void CuentaBancariaLogger_VerifyEjemplo()
        {
            var loggeGeneralMock = new Mock<ILoggerGeneral>();

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggeGeneralMock.Object);
            cuentaBancaria.Desposito(100);
            Assert.That(cuentaBancaria.GetBalance,Is.EqualTo(100));

            //Verifica cuantas veces el mock esta llamando al metodo .Message

            loggeGeneralMock.Verify(u=> u.Message(It.IsAny<string>()), Times.Exactly(3));
            loggeGeneralMock.VerifySet(u => u.PrioridadLogger=100, Times.Exactly(1));
            loggeGeneralMock.Verify(u => u.Message("Visita VaxiDrez.com"), Times.AtLeastOnce);
            loggeGeneralMock.VerifyGet(u => u.PrioridadLogger, Times.Exactly(1));



        }


    }
}
