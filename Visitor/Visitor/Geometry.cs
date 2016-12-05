using System.Collections.Generic;
using Visitor.Figures;

namespace Visitor
{
    public class Geometry
    {
        private List<IFigure> figures;

        public Geometry()
        {
            figures = new List<IFigure>();
        }

        public void AddFigure(IFigure figure)
        {
            figures.Add(figure);
        }

        public void Accept(Visitors.Visitor visitor)
        {
            foreach (IFigure figure in figures)
                figure.Accept(visitor);
        }

    }
}