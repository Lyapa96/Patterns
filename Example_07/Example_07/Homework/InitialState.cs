using System;
using System.Data;

namespace Example_07.Homework
{
    internal class InitialState : IStateMachine
    {
        public void MakeMoney(СopyingMachine machine, int money)
        {
            Console.WriteLine($"Внесли {money} рублей");
            machine.State = new ChooseMediaState();
        }

        public void SelectMedia(СopyingMachine machine, string media)
        {
            Console.WriteLine("Нет денег");            
        }

        public void SelectDocument(СopyingMachine machine, string filename)
        {
            Console.WriteLine("Нет денег");
        }

        public void PrintDocument(СopyingMachine machine)
        {
            Console.WriteLine("Нет денег");
        }

        public void GiveChange(СopyingMachine machine)
        {
            Console.WriteLine("Нет денег");
        }
    }
}