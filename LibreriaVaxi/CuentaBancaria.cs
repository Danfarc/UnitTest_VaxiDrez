using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    public class CuentaBancaria
    {
        private readonly ILoggerGeneral _loggerGeneral;

        public int balance { get; set; }
        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {
            balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Desposito(int monto)
        {
            _loggerGeneral.Message($"Esta depositando la cantidad de {monto}");
            _loggerGeneral.Message("Es otro Texto");
            _loggerGeneral.Message("Visita VaxiDrez.com");
            _loggerGeneral.PrioridadLogger = 100;
            var prioridad = _loggerGeneral.PrioridadLogger;
            balance += monto;
            return true;
        }

        public bool Retiro (int monto)
        {
            if(monto <= balance)
            {
                _loggerGeneral.LogDataBases("Monto de retiro:"+ monto.ToString());
                balance -= monto;
                return _loggerGeneral.LogBalanceDespuesRetiro(balance);
            }

            return _loggerGeneral.LogBalanceDespuesRetiro(balance-monto);
        }

        public int GetBalance()
        {
            return balance;
        }


    }
}
