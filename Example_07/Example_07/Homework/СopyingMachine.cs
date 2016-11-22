namespace Example_07.Homework
{
    public class СopyingMachine
    {
        public IStateMachine State { get; set; }

        public СopyingMachine()
        {
            State = new InitialState();
        }

        public void MakeMoney(int money)
        {
            State.MakeMoney(this,money);
        }

        public void SelectMedia(string media)
        {
            State.SelectMedia(this,media);
        }

        public void SelectDocument(string filename)
        {
            State.SelectDocument(this,filename);
        }

        public void PrintDocument()
        {
            State.PrintDocument(this);
        }

        public void GiveDelivery()
        {
            State.GiveChange(this);
        }
    }

    
}