using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCurrencyPair
{
    public class Core
    {
        public DateTime Date { get; set; }
        public string? Currency { get; set; }
        public double Value { get; set; }

        public Core(DateTime date, string currency, double value)
        {
            Date = date;
            Currency = currency;
            Value = value;
        }

        public void Print()
        {
            Console.WriteLine($"Дата: {Date} Валютная пара: {Currency} Отношение валютных пар: {Value}");
        }
    }
}
