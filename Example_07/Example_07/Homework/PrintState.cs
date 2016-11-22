using System;

namespace Example_07.Homework
{
    internal class PrintState : IStateMachine
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
            Console.WriteLine($"Изменили файл на - {filename}");
            machine.State = new PrintState();
        }

        public void PrintDocument(СopyingMachine machine)
        {
            Console.WriteLine("Распечатали документ");
            machine.State = new ChooseMediaState();
        }

        public void GiveChange(СopyingMachine machine)
        {
            Console.WriteLine("Вернули деньги");
            machine.State = new InitialState();
        }
    }
}