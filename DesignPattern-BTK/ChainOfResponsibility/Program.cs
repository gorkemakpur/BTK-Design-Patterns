using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();


            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);


            Expense expense = new Expense { Detail = "Food", Amount = 1111 };


            manager.HandleExpense(expense);

            Console.ReadLine();
        }


        class Expense
        {
            public string Detail { get; set; }
            public decimal Amount { get; set; }
        }


        abstract class ExpenseHandlerBase
        {
            protected ExpenseHandlerBase Successor;//protected inherit edildiği sınıfta kullanılabilir
            public abstract void HandleExpense(Expense expense);
            public void SetSuccessor(ExpenseHandlerBase successor)
            {
                Successor = successor;
            }
        }

        class Manager : ExpenseHandlerBase
        {
            public override void HandleExpense(Expense expense)
            {
                if (expense.Amount <= 100)
                {
                    Console.WriteLine("Manager Handled The Expense");
                }
                else if (Successor != null)
                {
                    Console.WriteLine("Manager Cant Handled this operation. Operation redirect to Vice President");
                    Successor.HandleExpense(expense);
                }
            }
        }

        class VicePresident : ExpenseHandlerBase
        {
            public override void HandleExpense(Expense expense)
            {
                if (expense.Amount > 100 && expense.Amount <= 1000)
                {
                    Console.WriteLine("Vice President Handled The Expense");
                }
                else if (Successor != null)
                {
                    Console.WriteLine("Vice President Cant Handled this operation. Operation redirect to President");
                    Successor.HandleExpense(expense);
                }
            }
        }


        class President : ExpenseHandlerBase
        {
            public override void HandleExpense(Expense expense)
            {
                if (expense.Amount > 1000)
                {
                    Console.WriteLine("President Handled The Expense");
                }
                else if (Successor != null)
                {
                    Successor.HandleExpense(expense);
                }

            }
        }


    }
}

