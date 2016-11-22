using System;
using NUnit.Framework;

namespace Example_07.Homework
{
    public class CopingMachine_should
    {  
        [Test]      
        public void RightWork()
        {
            var machine = new СopyingMachine();
            machine.MakeMoney(10);
            machine.SelectMedia("USBflash");
            machine.SelectDocument("1.txt");
            machine.PrintDocument();
            machine.GiveDelivery();
        }

        [Test]
        public void RightWorkWhenIncorrectUse()
        {
            var machine = new СopyingMachine();
            machine.MakeMoney(10);
            machine.SelectMedia("USBflash");            
            machine.PrintDocument();
            machine.SelectDocument("1.txt");
            machine.SelectMedia("wi-fi");
            machine.PrintDocument();
            machine.GiveDelivery();
        }

        [Test]
        public void ReturnInInitialStateAfterGettingDelivery()
        {
            var machine = new СopyingMachine();
            machine.MakeMoney(10);
            machine.SelectMedia("USBflash");
            machine.GiveDelivery();

            machine.MakeMoney(50);
            machine.SelectMedia("USBflash");
            machine.SelectDocument("1.txt");
            machine.GiveDelivery();

            machine.GiveDelivery();
        }


        [Test]
        public void MakeMoneyInAnyState()
        {
            var machine = new СopyingMachine();
            machine.MakeMoney(10);
            machine.SelectMedia("USBflash");
            machine.MakeMoney(10);
            machine.SelectDocument("1.txt");
            machine.MakeMoney(10);
            machine.PrintDocument();
            machine.MakeMoney(10);
            machine.GiveDelivery();
        }
    }
}