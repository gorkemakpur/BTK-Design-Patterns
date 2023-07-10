using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            ProductManager pm = new ProductManager();
            pm.Attach(customerObserver);
            pm.Attach(new EmployeeObserver());

            pm.Detach(customerObserver);


            pm.UpdatePrice();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var item in _observers)
            {
                item.Update();
            }
        }
    }


    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Customer : Product Price Changed!!");
        }
    }


    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Employee : Product Price Changed!!");
        }
    }


}
