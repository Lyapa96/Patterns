using System;
using System.Diagnostics;
using Example_07.Mediators;

namespace Example_07.Homework
{
    internal class ChooseMediaState : IStateMachine
    {
        public void MakeMoney(СopyingMachine machine, int money)
        {
            Console.WriteLine($"Добавили {money} рублей");
        }

        public void SelectMedia(СopyingMachine machine, string media)
        {
            Console.WriteLine($"Выбрали носитель - {media}");
            machine.State = new ChooseDocumentState();
        }

        public void SelectDocument(СopyingMachine machine, string filename)
        {
            Console.WriteLine("Носитель не выбран");
        }

        public void PrintDocument(СopyingMachine machine)
        {
            Console.WriteLine("Носитель и файл не выбраны");
        }

        public void GiveChange(СopyingMachine machine)
        {
            Console.WriteLine("Вернули деньги");
            machine.State = new InitialState();
        }
    }
}