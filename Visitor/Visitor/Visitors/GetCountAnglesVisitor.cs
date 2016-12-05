using System;
using Visitor.Figures;

namespace Visitor.Visitors
{
    public class GetCountAnglesVisitor : Visitor
    {
        public override void VisitCircle(Circle circle)
        {
            var angleCount = 0;
            Console.WriteLine("У круга {0} углов",angleCount);
        }

        public override void VisitRectangle(Rectangle rectangle)
        {
            var angleCount = 4;
            Console.WriteLine("У прямоугольника {0} угла", angleCount);
        }

        public override void VisitTriangle(Triangle triangle)
        {
            var angleCount = 3;
            Console.WriteLine("У треугольника {0} угла", angleCount);
        }
    }
}