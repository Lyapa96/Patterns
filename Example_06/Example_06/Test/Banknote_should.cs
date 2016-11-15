using System;
using Example_06.ChainOfResponsibility;
using NUnit.Framework;

namespace Example_06.Test
{
    public class Banknote_should
    {
        [Test]
        public void throwExceptionIfIncorrectValue()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var banknote = new Banknote(CurrencyType.Dollar, "123a");
            });
        }

        [TestCase("1234",ExpectedResult = "1234")]
        [TestCase("100500",ExpectedResult = "100500")]
        public string beCreatedCorrectly(string input)
        {
            var banknote = new Banknote(CurrencyType.Dollar, input);
            return banknote.Value;
        }
    }
}