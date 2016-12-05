using System.Drawing;
using System.Reflection;

namespace Visitor.Figures
{
    public class Circle : IFigure
    {
        public Point CenterPoint;
        public double Radius;

        public Circle(Point centerPoint,double radius)
        {
            CenterPoint = centerPoint;
            Radius = radius;
        }


        public void Accept(Visitors.Visitor visitor)
        {
            visitor.VisitCircle(this);
        }
    }
}