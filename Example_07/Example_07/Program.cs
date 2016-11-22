using System;
using Example_07.Mediators;
using Example_07.Observers;
using Example_07.States;

namespace Example_07
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //ObserverExample();
            //MediatorExample();
            StateExample();

            Console.WriteLine();
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static void ObserverExample()
        {
            var observer = new LessonObserver();

            var student1 = new Student("Adam");
            var student2 = new Student("Peter");
            var student3 = new Student("Max");

            var lector = new Lector("Prof. Smith");

            observer.Attach(student1);
            observer.Attach(student2);
            observer.Attach(student3);
            observer.Attach(lector);

            student1.Say("something");
            Console.WriteLine();

            student2.Say("some noize!");
            Console.WriteLine();

            observer.Detach(student1);
            student3.Say("question?");
            Console.WriteLine();

            Console.WriteLine("Ring");
            observer.Ring();
            Console.WriteLine();
        }

        private static void MediatorExample()
        {
            var badDataGenerator = new BadDataGenerator();
            badDataGenerator.Run();
            Console.WriteLine();

            var goodDataGenerator1 = new GoodDataGenerator();
            var mediator1 = new DefaultConsoleWriterMediator(goodDataGenerator1, new ConsoleWriter());
            goodDataGenerator1.Run();
            Console.WriteLine();

            var goodDataGenerator2 = new GoodDataGenerator();
            var mediator2 = new RedConsoleWriterMediator(goodDataGenerator2, new RedConsoleWriter());
            goodDataGenerator2.Run();
            Console.WriteLine();
        }

        private static void StateExample()
        {
            var context1 = new ConnectionContext("Url_1");
            context1.Connect();
            context1.Read();
            context1.Close();
            Console.WriteLine();

            try
            {
                var context2 = new ConnectionContext("Url_2");
                context2.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"context2: {ex.Message}");
            }
            Console.WriteLine();

            try
            {
                var context3 = new ConnectionContext("Url_3");
                context3.Connect();
                context3.Close();
                context3.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"context3: {ex.Message}");
            }
            Console.WriteLine();
        }
    }
}
