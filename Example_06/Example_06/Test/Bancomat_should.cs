using Example_06.ChainOfResponsibility;
using NUnit.Framework;

namespace Example_06.Test
{
    public class Bancomat_should
    {
        private static readonly TestCaseData[] BanknotesCase =
        {
            new TestCaseData(new Banknote(CurrencyType.Ruble, "2000")).Returns("1000*2 Ruble"),
            new TestCaseData(new Banknote(CurrencyType.Ruble, "2300")).Returns("1000*2 100*3 Ruble"),
            new TestCaseData(new Banknote(CurrencyType.Ruble, "2350")).Returns("1000*2 100*3 50*1 Ruble"),
            new TestCaseData(new Banknote(CurrencyType.Ruble, "2370")).Returns("1000*2 100*3 50*1 10*2 Ruble"),
            new TestCaseData(new Banknote(CurrencyType.Ruble, "2970")).Returns("1000*2 500*1 100*4 50*1 10*2 Ruble"),
            new TestCaseData(new Banknote(CurrencyType.Ruble, "2977")).Returns("1000*2 500*1 100*4 50*1 27 - не валидная сумма"),
            new TestCaseData(new Banknote(CurrencyType.Eur, "100500")).Returns("1000*100 500*1 Eur"),
            new TestCaseData(new Banknote(CurrencyType.Dollar, "10")).Returns("10*1 Dollar"),
        };

        [TestCaseSource(nameof(BanknotesCase))]
        public string returnRightBanknotes(IBanknote banknote)
        {
            var bancomat = new Bancomat();            
            return bancomat.Cash(banknote);
        }
    }
}