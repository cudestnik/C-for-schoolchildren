using System;
class WriteAFewLines
{
    static void Main()
    {
        Console.WriteLine("Введите Ваше любимое слово : ");
        // Сохраняем в строковой переменной введенное пользователем слово
        string favouriteWord = Console.ReadLine();

        Console.WriteLine("Сколько раз его напечатать? ");
        // Сохраняем в целочисленной переменной введенное число
        // (При неправильном вводе числа произойдет ошибка)
        int numberOfTimes = Convert.ToInt32(Console.ReadLine());

        // Выводим на экран слово указанное количество раз
        for (int i = 0; i < numberOfTimes; i++)
        {
            Console.WriteLine(favouriteWord);
        }

        // Ожидаем нажатия клавиши ВВОД
        Console.ReadLine();
    }
}

