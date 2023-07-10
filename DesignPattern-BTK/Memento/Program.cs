using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                ISBN = "12345",
                Title="Sefiller",
                Author="Victor Hugo"
            };
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.ISBN = "54321";
            book.Title = "VICTOR HUGO";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();



            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        DateTime _lastEdited;

        public string Title { get { return _title; } set { _title = value; SetLastEdited(); } }
        public string Author { get { return _author; } set { _author = value; SetLastEdited(); } }
        public string ISBN { get { return _isbn;} 
            set 
            {
                _isbn = value;
                SetLastEdited();
            } 
        }
        private void SetLastEdited()
        {
            _lastEdited = DateTime.Now;
        }
        public Memento CreateUndo()
        {
            return new Memento(_isbn,_title,_author,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _lastEdited = DateTime.Now;
            _isbn =memento.Isbn;    
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2},{3}",ISBN,Title,Author,_lastEdited);
        }

    }
    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }


        public Memento(string ısbn, string title, string author, DateTime lastEdited)
        {
            Isbn = ısbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }


}
