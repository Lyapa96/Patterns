using System.Drawing;

namespace Visitor.Figures
{
    public class Triangle : IFigure
    {
        public Point CenterPoint;
        public double SideA => 3;
        public double SideB => 4;
        public double SideC => 5;

        public Triangle(Point centerPoint)
        {
            CenterPoint = centerPoint;
        }

        public void Accept(Visitors.Visitor visitor)
        {
            visitor.VisitTriangle(this);
        }
    }
}