using System;


namespace Example_06.ChainOfResponsibility
{
    public enum CurrencyType
    {
        Eur,
        Dollar,
        Ruble
    }

    public interface IBanknote
    {
        CurrencyType Currency { get; }
        string Value { get; }
    }

    public class Bancomat
    {
        private readonly BanknoteHandler handler;

        public Bancomat()
        {
            handler = new BanknoteHandler(null, 10);
            handler = new BanknoteHandler(handler, 50);
            handler = new BanknoteHandler(handler, 100);
            handler = new BanknoteHandler(handler, 500);
            handler = new BanknoteHandler(handler, 1000);
        }

        public bool Validate(string banknote)
        {
            return handler.Validate(banknote);
        }

        public string Cash(IBanknote banknote)
        {
            return handler.Cash(banknote);
        }
    }

    public class BanknoteHandler
    {
        private readonly BanknoteHandler nextHandler;
        private readonly int nominalValue;

        public BanknoteHandler(BanknoteHandler nextHandler, int nominalValue)
        {
            this.nextHandler = nextHandler;
            this.nominalValue = nominalValue;
        }

        public bool Validate(string banknote)
        {
            return nextHandler != null && nextHandler.Validate(banknote);
        }


        public string Cash(IBanknote banknote)
        {
            var value = int.Parse(banknote.Value);
            var numberOfBanknotes = value/nominalValue;

            if (IsExisitsWholeRemainder(value, numberOfBanknotes))
            {
                var newBanknote = new Banknote(banknote.Currency, (value - nominalValue*numberOfBanknotes).ToString());
                return nominalValue + "*" + numberOfBanknotes + " " + nextHandler.Cash(newBanknote);
            }
            if (numberOfBanknotes == 0)
            {
                if (nextHandler != null)
                {
                    var newBanknote = new Banknote(banknote.Currency, (value%nominalValue).ToString());
                    return nextHandler.Cash(newBanknote);
                }
                return banknote.Currency.ToString();
            }
            if (nextHandler != null)
            {
                var newBanknote = new Banknote(banknote.Currency,
                    (int.Parse(banknote.Value)%nominalValue).ToString());
                return nominalValue + "*" + numberOfBanknotes + " " + nextHandler.Cash(newBanknote);
            }
            if (nextHandler == null && value%nominalValue != 0)
            {
                return numberOfBanknotes*10 + value%nominalValue + " - не валидная сумма";
            }
            return nominalValue + "*" + numberOfBanknotes + " " + banknote.Currency.ToString();
        }


        private bool IsExisitsWholeRemainder(int value, int numberOfBanknotes)
        {
            var firstNumber = (int) Char.GetNumericValue((value.ToString()[0]));
            return (firstNumber*Math.Pow(10, value.ToString().Length - 1) - nominalValue*numberOfBanknotes > 0 &&
                    numberOfBanknotes != 0);
        }
    }
}