using System.Collections.Generic;
using System.Threading;

namespace Example_07.Mediators
{
    public class BadDataGenerator
    {
        private readonly ConsoleWriter _consoleWriter;

        public BadDataGenerator()
        {
            _consoleWriter = new ConsoleWriter();
        }

        public void Run()
        {
            foreach (var str in Data)
            {
                _consoleWriter.Write(str);
            }            
        }

        private static IEnumerable<string> Data
        {
            get
            {
                yield return "str_1";
                yield return "str_2";
                yield return "str_3";
                yield return "str_4";
                yield return "str_5";
            }
        }
    }
}
