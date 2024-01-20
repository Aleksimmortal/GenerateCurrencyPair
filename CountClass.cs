using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCurrencyPair
{
    public class CountClass
    {
        public void Circle(object obj)
        {
            Random random = new Random();
            var objCreate = new CreateCurrencyPair();

            var saveCP = new Core(DateTime.Now, "Currency pair RUR/USD",
                Math.Round(((random.NextDouble() * 0.019) + 0.011), 3));

            saveCP.Print();
            objCreate.Create(saveCP);

           
        }
    }
}
