using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    public class OperacionXUnitTests
    {
        [Fact]
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
            Assert.Equal(119,resultado);

        }

        [Theory]
        [InlineData(3,false)]
        [InlineData(5,false)]
        [InlineData(7,false)]
        public void IsValorPar_InputNumeroImpar_GetValorFalso(int numeroImpar, bool expectedResult)
        {
            Operacion op = new();
            //int numeroImpar = 3;

            bool resultado = op.IsValorPar(numeroImpar);

            Assert.Equal(expectedResult,resultado);

        }

        [Theory]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(20)]
        public void IsValorPar_InputNumeroPar_GetValorTrue(int numeroPar)
        {
            Operacion op = new();
            //int numeroPar = 2;
            bool resultado = op.IsValorPar(numeroPar);
            Assert.True(resultado);

        }

        [Theory]
        [InlineData(2.2,1.2)] //3.4
        [InlineData(2.23, 1.24)] //3.47
        public void SumarDecimal_InputDosNumerosDecimales_GetValorCorrecto(double decimal1Test, double decimal2Test)
        {
            //1. arrange
            //Inicializar las variables o componentes que ejecutaran el test
            Operacion op = new();

            //2. Act
            double resultado = op.SumarDecimal(decimal1Test, decimal2Test);



            //3. Assert
            Assert.Equal(3.4, resultado, 0);

        }

        [Fact]
        public void GetListaNumeroImpares_InputMinimoMaximoIntervalos_ReturnsListaImpares()
        {
            Operacion op = new();
            List<int> numerosImparesEsperados = new() { 5, 7, 9 };

            List<int> resultados = op.GetListaNumeroImpares(5, 10);

            Assert.Equal(numerosImparesEsperados, resultados);
            Assert.Contains(5,resultados);
            Assert.NotEmpty(resultados);
            Assert.Equal(3,resultados.Count);
            Assert.DoesNotContain(100,resultados);
            Assert.Equal(resultados.OrderBy(u=>u),resultados);

        }


    }
}
