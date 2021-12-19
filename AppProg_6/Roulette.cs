using System;
using System.Collections.Generic;

class Roulette
{
    private int NumberOfKegs;
    private List<int> Kegs;
    private Random Rnd = new Random();
    private MyStupidLogger Logger;
    public bool IsEmpty { get; private set; }
    public Roulette(MyStupidLogger logger)
    {
        Logger = logger;
        NumberOfKegs = InputCount();
        IsEmpty = false;
        Kegs = CreateKegsMassive(NumberOfKegs);
        Console.WriteLine("Для вытягивания бочонка нажимайте любую кнопку.\n");
    }

    private bool CheckRemainderOfKegs()
    {
        if (Kegs.Count == 0)
        {
            Logger.CallToInfo("Бочонки успешно закончились.");
            Console.WriteLine("Бочонки закончились!");
            return true;
        }
        return false;
    }

    public void PullOutKeg()
    {
        var index = Rnd.Next(0, Kegs.Count);
        var keg = Kegs[index];
        Console.WriteLine("Вы вытащили бочонок под номером: " + keg);
        Logger.CallToInfo("Выбран бочонок под номером " + keg + ".");
        DeleteKegFromKegs(index);
        Logger.CallToInfo("Бочонок под номером " + keg + " успешно удалён из основоного списка.");
        IsEmpty = CheckRemainderOfKegs();
    }

    private void DeleteKegFromKegs(int index)
    {
        Kegs.RemoveAt(index);
    }

    private List<int> CreateKegsMassive(int count)
    {
        Logger.StartStopWatch();
        var result = new List<int>();
        for (var i = 0; i < count; i++)
        {
            result.Add(i + 1);
        }
        Logger.StopStopWatch("Список бочонков успешно создан.");
        return result;
    }

    private int InputCount()
    {
        var error = true;
        int result = 0;
        Console.Write("Введите число бочонков: ");
        while (error)
        {
            if (int.TryParse(Console.ReadLine(), out result))
            {
                if (result > 0)
                {
                    Logger.CallToInfo("\nВвод пользователя принят: " + result, MyStupidLogger.GetCallerName());
                    error = false;
                }
                else
                {
                    Logger.CallToError("\nВвод пользователя отклонён: Ввёденное число меньше 1.", MyStupidLogger.GetCallerName());
                    Console.Write("Нужно ввести положительное число, большее 0, попробуйте снова: ");
                }
            }
            else
            {
                Logger.CallToError("\nВвод пользователя отклонён: Ввод не числа.", MyStupidLogger.GetCallerName());
                Console.Write("Вы ввели не число, попробуйте снова: ");
            }
        }
        return result;
    }
}
