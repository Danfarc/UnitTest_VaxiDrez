using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    [TestFixture]
    public class OperacionNUnitTest
    {
        [Test]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //1. arrange
            //Inicializar las variables o componentes que ejecutaran el test
            Operacion op = new();
            int numero1Test = 50;
            int numero2Test = 69;

            //2. Act
            int resultado = op.SumarNumeros(numero1Test, numero2Test);

            //3. Assert
            Assert.That(resultado, Is.EqualTo(119));

        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        public bool IsValorPar_InputNumeroImpar_GetValorFalso(int numeroImpar)
        {
            Operacion op = new();
            //int numeroImpar = 3;

            bool resultado = op.IsValorPar(numeroImpar);

            //Assert.IsFalse(resultado);
            //Assert.That(resultado, Is.EqualTo(false));

            return resultado;
        }

        [Test]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(20)]
        public void IsValorPar_InputNumeroPar_GetValorTrue(int numeroPar)
        {
            Operacion op = new();
            //int numeroPar = 2;

            bool resultado = op.IsValorPar(numeroPar);

            //Modelo Clasico
            Assert.IsTrue(resultado);
            //Modelo de restriccion
            Assert.That(resultado, Is.EqualTo(true));
        }

        [Test]
        [TestCase(2.2,1.2)] //3.4
        [TestCase(2.23, 1.24)] //3.47
        public void SumarDecimal_InputDosNumerosDecimales_GetValorCorrecto(double decimal1Test, double decimal2Test)
        {
            //1. arrange
            //Inicializar las variables o componentes que ejecutaran el test
            Operacion op = new();

            //2. Act
            double resultado = op.SumarDecimal(decimal1Test, decimal2Test);



            //3. Assert
            Assert.AreEqual(3.4, resultado,0.1);

        }


    }
}
