using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer= new Customer { Id=1, City="İstanbul",FirstName="Aziz",LastName="Akpur"};
            Console.WriteLine(customer.FirstName);

            Customer customer1 =(Customer) customer.Clone();
            customer1.FirstName = "Görkem";


            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer1.FirstName);
            Console.ReadLine();

        }


    }
    //entitylerde olan ortak elemanları prototype desen ile klonlayarak maaliyetten
    //tasarruf edebiliyoruz
    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }    
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

}

