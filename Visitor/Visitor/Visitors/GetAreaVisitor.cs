using System;
using Visitor.Figures;

namespace Visitor.Visitors
{
    public class GetAreaVisitor : Visitor
    {
        public override void VisitCircle(Circle circle)
        {
            var area = Math.PI*circle.Radius*circle.Radius;
            Console.WriteLine("Площадь круга: "+area);
        }

        public override void VisitRectangle(Rectangle rectangle)
        {
            var area = rectangle.SideA*rectangle.SideB;
            Console.WriteLine("Площадь прямоугольника: "+ area);
        }

        public override void VisitTriangle(Triangle triangle)
        {
            var area = triangle.SideA * triangle.SideB*0.5;
            Console.WriteLine("Площадь треугольника: " + area);
        }
    }
}