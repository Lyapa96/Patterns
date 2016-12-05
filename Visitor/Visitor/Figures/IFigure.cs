namespace Visitor.Figures
{
    public interface IFigure
    {
        void Accept(Visitors.Visitor visitor);
    }
}