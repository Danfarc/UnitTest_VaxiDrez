using LibreriaVaxi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxiMSTest
{
    [TestClass]
    public class OperacionMSTest
    {
        [TestMethod]
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
            Assert.AreEqual(119, resultado);

        }
    }
}
