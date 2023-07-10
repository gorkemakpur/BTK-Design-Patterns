using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();//mediator bir nevi arabulucu olarak çalışır

            //öğretmen
            Teacher aziz = new Teacher(mediator) {Name="Aziz"};
            mediator.Teacher = aziz;
            //1. öğrenci
            Student gorkem = new Student(mediator);
            gorkem.Name = "Görkem";

            //2. öğrenci
            Student akpur = new Student(mediator);
            akpur.Name = "Akpur";

            mediator.Students = new List<Student> {akpur,gorkem};

            aziz.SendNewImageUrl("Slide1.jpg");
            Console.WriteLine("-----------------");

            aziz.ReceiveQuestion("is it true ?", gorkem);

            gorkem.ReceiveAnswer("true");


            Console.ReadLine();

        }
    }


    abstract class CourseMember
    {
        protected Mediator Mediator;
        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }


    class Teacher : CourseMember
    {
        public string Name { get; set; }    
        public Teacher(Mediator mediator) : base(mediator)
        {
        }


        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received question from {0}, Question : {1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        public void ReceiveImage(string url)
        {
            Console.WriteLine("Student Received Image : {0}",url);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student Received Answer : {0}",answer);
        }
    }


    class Mediator//Desenin adı kullanıldı. Mesajlaşma kısmının oluştuğu ksıım diyebilirz.
                  //Teacher yada student soru sorduğunda mediator üzerinden cevap döndürülür diyebiliriz
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }





}
