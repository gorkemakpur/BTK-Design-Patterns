using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager aziz = new Manager { Name = "Aziz", Salary = 1000 };
            Manager gorkem = new Manager { Name = "Gorkem", Salary = 750 };


            Worker ali = new Worker { Name = "Ali", Salary = 600 };
            Worker ayse = new Worker { Name = "Ayse", Salary = 700 };
            Worker fatma = new Worker { Name = "Fatma", Salary = 800 };

            aziz.SubOrdinates.Add(gorkem);
            gorkem.SubOrdinates.Add(ali);
            gorkem.SubOrdinates.Add(ayse);
            gorkem.SubOrdinates.Add(fatma);


            OrganisationalStructure organisationalStructure = new OrganisationalStructure(aziz);
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();
            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);

            Console.ReadLine();

        }
    }


    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            SubOrdinates = new List<EmployeeBase>();
        }


        public List<EmployeeBase> SubOrdinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in SubOrdinates)
            {
                employee.Accept(visitor);
            }
        }
    }


    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }



    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }


    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }


    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} Salary increased to {1}", worker.Name, worker.Salary * (decimal)1.2);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} Salary increased to {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }
}

