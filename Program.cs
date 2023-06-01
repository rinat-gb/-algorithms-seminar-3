using System;

// разворот односвязного списка
//
namespace listrevert;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<int> myList = new List<int>();

        // заполняем список десятью случайными значениями
        for (int i = 0; i < 10; i++)
            myList.add(random.Next(1, 100));

        // выводим текущий список
        Console.WriteLine(string.Format("   Список до разворота: {0}", myList));

        // разворачиваем его
        myList.revert();

        // выводим результат
        Console.WriteLine(string.Format("Список после разворота: {0}", myList));
    }
}
