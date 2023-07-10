using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager();
            var customerManager= CustomerManager.CreateAsSingleton();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();

        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            lock( _lockObject )//burada nesneyi aynı anda 2 kişi isteyip üretirse singletonun dışına çıkıp 2 nesne üretilebilir
                //bunun önüne geçmek için defensive programming yaparak nesne üretiliyorsa kilitlenmesi sağlanır
            {
                if( _customerManager == null )
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }

    }
}
