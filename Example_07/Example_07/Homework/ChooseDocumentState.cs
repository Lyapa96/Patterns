using System;

namespace Example_07.Homework
{
    internal class ChooseDocumentState : IStateMachine
    {
        public void MakeMoney(СopyingMachine machine, int money)
        {
            Console.WriteLine($"Добавили {money} рублей");
        }

        public void SelectMedia(СopyingMachine machine, string media)
        {
            Console.WriteLine($"Изменили носитель на - {media}");
            machine.State = new ChooseDocumentState();
        }

        public void SelectDocument(СopyingMachine machine, string filename)
        {
            Console.WriteLine($"Выбрали файл - {filename}");
            machine.State = new PrintState();
        }

        public void PrintDocument(СopyingMachine machine)
        {
            Console.WriteLine("Файл не выбран");
        }

        public void GiveChange(СopyingMachine machine)
        {
            Console.WriteLine("Вернули деньги");
            machine.State = new InitialState();
        }
    }
}