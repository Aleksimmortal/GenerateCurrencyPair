using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenerateCurrencyPair
{
    public class CreateCurrencyPair
    {
        private string CurrencyPairNote = "D:\\Академия TOP\\Проект Wallet\\Currency.json";
        public void Create(Core notesPair)
        {
            var currencyNotes = new List<Core>();
            if (File.Exists(CurrencyPairNote))
            {
                using (FileStream fs = new FileStream(CurrencyPairNote, FileMode.OpenOrCreate))
                {
                    currencyNotes = JsonSerializer.Deserialize<List<Core>>(fs);
                }
            }
            currencyNotes.Add(notesPair);
            Write(currencyNotes);

        }

        private void Write(List<Core> notesPair)
        {
            using (FileStream fs = new FileStream(CurrencyPairNote, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<Core>>(fs, notesPair);
            }
        }
    }
}
