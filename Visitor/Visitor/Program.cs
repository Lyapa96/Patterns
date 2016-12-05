using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Figures;
using Visitor.Visitors;
using Rectangle = Visitor.Figures.Rectangle;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var center = new Point(0,0);

            var geometry = new Geometry();
            geometry.AddFigure(new Circle(center,4));
            geometry.AddFigure(new Rectangle(center));
            geometry.AddFigure(new Triangle(center));

            geometry.Accept(new DrawVisitor());
            geometry.Accept(new GetAreaVisitor());
            geometry.Accept(new GetCountAnglesVisitor());

            Console.ReadLine();
        }
    }
}
