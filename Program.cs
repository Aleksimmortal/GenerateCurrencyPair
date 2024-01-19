using System;
using System.Text.Json;

namespace CurrencyPair
{
    class Program
    {
        private const string CurrencyPairNote = "C:\\Users\\pollo\\OneDrive\\Desktop\\проект\\Currency.json";
        public class SaveCurrencyPair
        {
            public DateTime Date { get; set; }
            public string? CurrencyPair { get; set; }
            public double Value { get; set; }



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
                Write(currencyNotes);

            }

            public void Write(List<SaveCurrencyPair> notesPair)
            {
                using (FileStream fs = new FileStream(CurrencyPairNote, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize<List<SaveCurrencyPair>>(fs, notesPair);
                }
            }
        
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
           
                var saveCP = new SaveCurrencyPair
                {
                    Date = DateTime.Now,
                    CurrencyPair = "Currency pair RUR/USD",
                    Value = Math.Round(((random.NextDouble()* 0.019)+ 0.011),3)
                };
                saveCP.PrintCurrencyPair();
                saveCP.Create(saveCP);
            }
        }

        
        
    
}

