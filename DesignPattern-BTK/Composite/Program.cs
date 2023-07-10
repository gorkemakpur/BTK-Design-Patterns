using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee aziz = new Employee { Name = "Aziz Görkem" };//Aziz
            Employee gorkem = new Employee { Name = "Görkem Akpur" };//Azizin çalışanı
            aziz.AddSubOrdinate(gorkem);

            Employee akpur = new Employee { Name = "Akpur Aziz" };//Azizin çalışanı
            aziz.AddSubOrdinate(akpur);

            Employee ahmet = new Employee { Name = "ahmet ahmet" };//Görkemin çalışan
            gorkem.AddSubOrdinate(ahmet);

          



            Contractor ali = new Contractor { Name = "Ali Ali" };
            akpur.AddSubOrdinate(ali);

            Employee Ayse = new Employee { Name = "Ayşe Ayşe" };//Görkemin çalışan
            gorkem.AddSubOrdinate(Ayse);


            Console.WriteLine("{0}",aziz.Name);
            foreach (Employee manager in aziz)
            {
                Console.WriteLine("  {0}",manager.Name);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }

            Console.ReadLine();
        }
    }



    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subOrdinates = new List<IPerson>();

        public void AddSubOrdinate(IPerson person)
        {
            _subOrdinates.Add(person);
        }
        public void RemoveSubOrdinate(IPerson person)
        {
            _subOrdinates.Remove(person);
        }
        public IPerson GetSubOrdinate(int index)
        {
            return _subOrdinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var item in _subOrdinates)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }




}
