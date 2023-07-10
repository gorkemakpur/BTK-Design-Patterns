using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager pm = new ProductManager(new LoggerHaAdapter());
            pm.Save();
            Console.ReadLine();
            
        }
    }

    //adapter deseni denemek için yapıldı
    class LoggerHa
    {
        public void Loggg(string message)
        {
            Console.WriteLine("Loglara ekledim : {0}",message);
        }
    }

    class LoggerHaAdapter : ILogger
    {
        public void Log(string message)
        {
            LoggerHa loggerHa = new LoggerHa();
            loggerHa.Loggg(message);
        }
    }

    //--------------------

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }


    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged with ED: {0}", message);
        }
    }

    //nugetten indirildiği varsayılsın bu classa dokunamıyoruz bize paket olarak gelnmiş
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4net: {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }






}
