using System;
using System.Text.Json;

namespace CurrencyPair
{
    class Program
    {
        
        public class SaveCurrencyPair
        {
            public DateTime Date { get; set; }
            public string? CurrencyPair { get; set; }
            public double Value { get; set; }

            public void PrintCurrencyPair()
            {
                Console.WriteLine($"Дата: {Date} Валютная пара: {CurrencyPair} Отношение валютных пар: {Value}");
            }
        }

        static void Main(string[] args)
        {
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            // создание таймера, 3000 это периодичность вывода информации в миллисекундах, т.е. 3 секунды
            Timer timer = new Timer(tm, null, 0, 3000);
            Console.ReadLine();
        }

        public static void Count(object obj)
        {
            Random random = new Random();
            for (int i = 0; i < 1; i++)
            {
                var saveCP = new SaveCurrencyPair
                {
                    Date = DateTime.Now,
                    CurrencyPair = "Currency pair RUR/USD",
                    Value = Math.Round(((random.NextDouble()* 0.019)+ 0.011),3)
                };
                saveCP.PrintCurrencyPair();
                Create(saveCP);
            }
        }

        private string CurrencyPairNote = "D:\\Академия TOP\\Проект Wallet\\Currency.json";
        public void Create(SaveCurrencyPair notesPair)
        {
            var currencyNotes = new List<SaveCurrencyPair>();
            if (File.Exists(CurrencyPairNote))
            {
                using (FileStream fs = new FileStream(CurrencyPairNote, FileMode.OpenOrCreate))
                {
                    currencyNotes = JsonSerializer.Deserialize<List<SaveCurrencyPair>>(fs);
                }
            }
            currencyNotes.Add(notesPair);
            Write(notesPair);

        }

        public void Write (List<SaveCurrencyPair> notesPair)
        {
            using (FileStream fs = new FileStream(CurrencyPairNote, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<SaveCurrencyPair>>(fs, notesPair);
            }
        }
    }
    
}

