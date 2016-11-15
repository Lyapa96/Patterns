using System;

namespace Example_06.ChainOfResponsibility
{
    public class Banknote : IBanknote
    {
        public CurrencyType Currency { get; }
        private readonly int value;
        public string Value => value.ToString();

        public Banknote(CurrencyType currency, string value)
        {
            Currency = currency;
            if (!int.TryParse(value, out this.value))
            {
                throw new ArgumentException();
            }            
        }
    }
}