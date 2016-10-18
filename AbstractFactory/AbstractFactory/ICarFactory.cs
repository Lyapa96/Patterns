namespace AbstractFactory
{
    public interface ICarFactory
    {
        IBody CreateBody();
        IBumper CreateBumper();
        IEngine CreatEngine();
        IHeadlights CreateHeadlights();
    }
}