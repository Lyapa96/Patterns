using System;
using Example_04.Composites;

namespace Example_04
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //
            //
            MenuExample();

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void MenuExample()
        {
            var menu = new MenuComponent[]
            {
                new MenuLeaf("1. Leaf 1"),
                new MenuComposite("2. Composite", new[]
                {
                    new MenuLeaf("2.1. Admin page")
                }),
                new MenuComposite("3. Composite", new MenuComponent[]
                {
                    new MenuLeaf("3.1. Admin page"),
                    new MenuLeaf("3.2. Leaf"),
                    new MenuComposite("3.3 Composite", new[]
                    {
                        new MenuLeaf("3.3.1. Leaf")
                    })                
                })
            };

            foreach (var menuItem in menu)
            {
                if (menuItem.IsAvailable())
                {
                    Console.WriteLine(menuItem.Render());
                }
            }
        }
    }
}
