using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Example
{
    static void Main()
    {
        Console.WriteLine("Чего желаете?");
        List<int> cash = new List<int>();
        List<bool> state = new List<bool>();
        cash.Add(6454);
        cash.Add(6435);
        cash.Add(-4645);
        cash.Add(-534);
        state.Add(true);
        state.Add(true);
        state.Add(true);
        state.Add(true);
        while (true)
        {
            for (int i = 0; i < cash.Count; i++)
            {
                if (cash[i] < -100)
                {
                    state[i] = false;
                }
                else
                    state[i] = true;
            } 
            Console.WriteLine("Нажмите 1 - создание нового счёта");
            Console.WriteLine("Нажмите 2 - списать деньги со счёта");
            Console.WriteLine("Нажмите 3 - узнать ваш текущий баланс");
            Console.WriteLine("Нажмите 4 - увидеть все ваши счета");
            Console.WriteLine("Нажмите 5 - пополнить счёт");
            Console.WriteLine("Нажмите 6 - очистить экран");
            Console.WriteLine("Нажмите 7 - уничтожить счёт(доступно только при балансе свыше 50 рупий)");
            Console.WriteLine("Нажмите 8 - отсортировать счета(по возрастанию)");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine();
                    Console.WriteLine("Введите зачисляемую сумму на новый счёт(не менее 100 шейкелей)");
                    int bmoney = 0;
                    try
                    {
                        bmoney = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        goto case '1';
                    }

                    if (bmoney < 100)
                    {
                        Console.WriteLine("Повторите попытку, в этот раз с деньгой");
                        goto case '1';
                    }
                    cash.Add(bmoney);
                    state.Add(true);
                    break;
                case '2':
                    Console.WriteLine();
                    Console.WriteLine("Какой счёт должен уменьшиться?");

                    int n = 0;
                    try
                    {
                        n = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException) { goto case '2'; }
                    if (n >= cash.Count)
                    {
                        Console.WriteLine("Введите существующий счёт");
                        goto case '2';
                    }
                    if (!state[n - 1])
                    {
                        Console.WriteLine("Сий счёт недоступен");
                        goto case '2';
                    }
                    Console.WriteLine("Сколько желаете снять?");
                    int money = 0;
                    try
                    {
                        money = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException) { goto case '2'; }
                    if ( money < 100)
                    {
                        Console.WriteLine("Невозможно снять сумму меньше 100 шейкелей");
                        goto case '2';
                    }
                    cash[n - 1] -= money;
                    break;
                case '3':
                    Console.WriteLine();
                    int balance = 0;
                    Console.WriteLine("Ваш баланс:");
                    for (int i = 0; i < cash.Count; i++)
                        balance += cash[i];
                    Console.WriteLine(balance);
                    break;
                case '4':
                    Console.WriteLine();
                    Console.WriteLine("Все ваши счета:");
                    if (cash.Count == 0)
                    {
                        Console.WriteLine("А у вас их и нет");
                        
                    }
                    for (int i = 0; i < cash.Count; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, state[i] ? cash[i].ToString() : "Заблокирован, возможно надолго");
                    }
                    break;
                case '5':
                    Console.WriteLine();
                    Console.WriteLine("Введите номер счёта для пополнения");
                    int key = 0;
                    try
                    {
                        key = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException) { goto case '5'; }
                    if (key >= cash.Count)
                    {
                        Console.WriteLine("Введите номер существующего счёта");
                        goto case '5';
                    }
                    Console.WriteLine("Введите зачисляемую сумму на новый счёт(не меньше 100 рупий)");
                    int nsumm = 0;
                    try
                    {
                        nsumm = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        goto case '5';
                    }

                    if (nsumm < 100)
                    {
                        Console.WriteLine("Вот вам ещё одна попытка и в этот раз нужна сумма свыше 100 шейкелей.");
                        goto case '5';
                    }
                    cash[key - 1] += (nsumm);
                    break;
                case '6':
                    Console.Clear();
                    break;
                case '7':
                    Console.WriteLine();

                    int num = 0;
                    Console.WriteLine("Выберите счёт для уничтожения(весь ваш баланс выше 100 рупий вернется к вам");
                    try
                    {
                        num = int.Parse(Console.ReadLine());

                    }
                    catch (FormatException)
                    {
                        goto case '7';
                    }
                    if (num >= cash.Count)
                    {
                        Console.WriteLine("Введите существующий счёт");
                        goto case '7';
                    }
                    if (cash[num - 1] < 100)
                    {
                        Console.WriteLine("Недостаточно золота на счету для его уничтожения, вы всё ещё должны банку {0}", cash[num]);
                        goto case '7';
                    }
                    cash.RemoveAt(num - 1);
                    break;
                case '8':
                    Console.WriteLine();
                    int q = 0;
                    for (int j = 0; j < cash.Count; j++)
                    {
                        for (int i = cash.Count - 2; i >= 0; i--)
                        {
                            if (cash[i] > cash[i + 1])
                            {
                                int help = cash[i + 1];
                                cash[i + 1] = cash[i];
                                cash[i] = help;
                                bool help2 = state[i + 1];
                                state[i + 1] = state[i];
                                state[i] = help2;

                            }
                        }
                    }

                    for (int i = 0; i < cash.Count; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, state[i] ? cash[i].ToString() : "Всё ещё заблокировано");
                    }
                    break;
                case '9':
                    int all = cash.Count;
                    for (int i = 0; i < all; i++)
                    {
                        cash.RemoveAt(0);
                        state.RemoveAt(0);
                    }
                    break;
                default:
                    Console.WriteLine("\nВыберите сщуествующую комнаду");

                    break;
            }

        }
    }
}