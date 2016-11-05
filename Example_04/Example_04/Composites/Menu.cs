using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example_04.Composites
{
    public abstract class MenuComponent
    {
        public string Name { get; }

        protected MenuComponent(string name)
        {
            Name = name;
        }

        public abstract bool IsAvailable();
        public abstract string Render();
    }

    public class MenuLeaf : MenuComponent
    {
        public MenuLeaf(string name) : base(name) { }

        public override bool IsAvailable()
        {
            return !Name.Contains("Admin page");
        }

        public override string Render() => $"* {Name}";
    }

    public class MenuComposite : MenuComponent
    {
        private IEnumerable<MenuComponent> Leafs { get; set; }

        public MenuComposite(string name, IEnumerable<MenuComponent> leafs) : base(name)
        {
            Leafs = leafs;
        }

        public override bool IsAvailable()
        {
            return Leafs.Any(i => i.IsAvailable());
        }

        public override string Render()
        {
            var stringBuilder = new StringBuilder($"* {Name} \n");
            foreach (var leaf in Leafs.Where(i => i.IsAvailable()))
            {
                stringBuilder.AppendLine($"\t- {leaf.Name}");
            }

            return stringBuilder.ToString();
        }
    }
}
