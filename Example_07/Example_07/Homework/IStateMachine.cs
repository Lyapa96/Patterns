using Example_07.States;

namespace Example_07.Homework
{
    public interface IStateMachine
    {
        void MakeMoney(СopyingMachine machine, int money);
        void SelectMedia(СopyingMachine machine, string media);
        void SelectDocument(СopyingMachine machine, string filename);
        void PrintDocument(СopyingMachine machine);
        void GiveChange(СopyingMachine machine);
    }
}