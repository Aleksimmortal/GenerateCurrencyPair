using GenerateCurrencyPair;
using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // устанавливаем метод обратного вызова
        var obj = new CountClass();
        TimerCallback tm = new TimerCallback(obj.Circle);
        // создание таймера, 3000 это периодичность вывода информации в миллисекундах, т.е. 3 секунды
        Timer timer = new Timer(tm, null, 0, 3000);
        Console.ReadLine();


    }
}
   

