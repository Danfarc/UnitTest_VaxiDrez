using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    public interface ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }
        void Message(string message);
        bool LogDataBases(string message);
        bool LogBalanceDespuesRetiro (int balanceDespuesRetiro);    
        string MessageConReturnStr(string message);
        bool MessageConOutParametroReturnBoolean(string str, out string outputStr);
        bool MessageConObjReferenciaReturnBoolean(ref Cliente cliente);

    }
    public class LoggerGeneral : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {
                Console.WriteLine("Exito");
                return true;
            }
            Console.WriteLine("Error");
            return false;

        }

        public bool LogDataBases(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageConObjReferenciaReturnBoolean(ref Cliente cliente)
        {
            return true;
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            outputStr = "Hola" + str;
            return true;
        }

        public string MessageConReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }
    public class LoggerFake : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            return true;
        }

        public bool LogDataBases(string message)
        {
            return true;
        }

        public void Message(string message)
        {

        }

        public bool MessageConObjReferenciaReturnBoolean(ref Cliente cliente)
        {
            return false;
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            outputStr = "Hola" + str;
            return true;
        }

        public string MessageConReturnStr(string message)
        {
            return message;
        }
    }
}
