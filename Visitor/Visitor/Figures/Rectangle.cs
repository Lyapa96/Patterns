using System.Drawing;

namespace Visitor.Figures
{
    public class Rectangle : IFigure
    {
        public Point CenterPoint;
        public double SideA => 3;
        public double SideB => 4;

        public Rectangle(Point centerPoint)
        {
            CenterPoint = centerPoint;
        }

        public void Accept(Visitors.Visitor visitor)
        {
            visitor.VisitRectangle(this);
        }
    }
}