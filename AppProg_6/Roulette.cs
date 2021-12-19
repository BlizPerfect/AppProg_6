using System;
using System.Collections.Generic;

class Roulette
{
    private int NumberOfKegs;
    private List<int> Kegs;
    private Random Rnd = new Random();
    public bool IsEmpty { get; private set; }
    public Roulette()
    {
        NumberOfKegs = InputCount();
        IsEmpty = false;
        Kegs = CreateKegsMassive(NumberOfKegs);
        Console.WriteLine("Для вытягивания бочонка нажимайте любую кнопку.\n");
    }

    private bool CheckRemainderOfKegs()
    {
        if (Kegs.Count == 0)
        {
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
        DeleteKegFromKegs(index);
        IsEmpty = CheckRemainderOfKegs();
    }

    private void DeleteKegFromKegs(int index)
    {
        Kegs.RemoveAt(index);
    }

    private List<int> CreateKegsMassive(int count)
    {
        var result = new List<int>();
        for (var i = 0; i < count; i++)
        {
            result.Add(i + 1);
        }
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
                    error = false;
                }
                else
                {
                    Console.Write("Нужно ввести положительное число, большее 0, попробуйте снова: ");
                }
            }
            else
            {
                Console.Write("Вы ввели не число, попробуйте снова: ");
            }
        }
        return result;
    }
}
