using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //business to decide factory
            return new EdLogger();
        }

    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //business to decide factory
            return new EddyLogger();
        }

    }



    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }

    public class EddyLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EddyLogger");
        }
    }



    public class CustomerManager
    {
        ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory=loggerFactory;
        }

        public void Save()
        {
            ILogger logger = _loggerFactory.CreateLogger();
            Console.WriteLine("Saved");
            logger.Log();
            
        }
    }
}
