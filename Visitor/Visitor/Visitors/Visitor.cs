using Visitor.Figures;

namespace Visitor.Visitors
{
    public abstract class Visitor
    {
        public abstract void VisitCircle(Circle circle);
        public abstract void VisitRectangle(Rectangle rectangle);
        public abstract void VisitTriangle(Triangle triangle);
    }
}