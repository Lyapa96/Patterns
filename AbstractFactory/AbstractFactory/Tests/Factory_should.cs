using AbstractFactory.AUDI;
using AbstractFactory.BMW;
using NUnit.Framework;
using FluentAssertions;

namespace AbstractFactory.Tests
{
    public class Factory_should
    {
        [Test]
        public void CreateEngineForBMW()
        {
            var factory = new BMWFactory();
            var engine = factory.CreatEngine();

            engine.Name.Should().BeEquivalentTo("двигатель от BMW");
        }

        [Test]
        public void CreateEngineForAUDI()
        {
            var factory = new AUDIFactory();
            var engine = factory.CreatEngine();

            engine.Name.Should().BeEquivalentTo("двигатель от AUDI");
        }
    }
}