using System;
using Visitor.Figures;

namespace Visitor.Visitors
{
    public class DrawVisitor : Visitor
    {
        public override void VisitCircle(Circle circle)
        {
            Console.WriteLine("Нарисован круг с центром в точке " + circle.CenterPoint);
        }

        public override void VisitRectangle(Rectangle rectangle)
        {
            Console.WriteLine("Нарисован прямоугольник с центром в точке " + rectangle.CenterPoint);
        }

        public override void VisitTriangle(Triangle triangle)
        {
            Console.WriteLine("Нарисован треугольник с центром в точке " + triangle.CenterPoint);
        }
    }
}