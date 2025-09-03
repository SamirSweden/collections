using System;
using System.Threading;

class Program
{
    static int balance = 1000000;
    static Random random = new Random();
    static string[] symbols = { "🍒", "🍋", "🍊", "💎", "7️⃣" };

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            ShowHeader();
            ShowMenu();

            var choice = Console.ReadKey(true).KeyChar;

            switch (choice)
            {
                case '1': PlaySlots(); break;
                case '2': ShowBalance(); break;
                case '3':
                    Console.WriteLine("\nДо свидания!");
                    return;
                default:
                    Console.WriteLine("\nНеверный выбор!");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
    static void ShowHeader()
    {
        System.Console.WriteLine("=========================================================");
        Console.WriteLine(   $"= Баланс: {balance} монет :: Status player              =");
        System.Console.WriteLine("=========================================================");
        Console.WriteLine(@"
            ⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢾⠱⢕⠠⢀⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⢆⢸⢣⠁⠛⡄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢠⢏⠨⢪⢫⣷⡻⢆⠀⠀⠀⠀
⠀⠀⠀⠀⣰⣯⢖⠆⠁⠀⣸⡈⠉⠀⠀⠀⠀
⠀⠀⠀⠀⡾⣇⡔⡳⠀⢠⢻⢳⣄⡀⠀⠀⠀
⠀⠀⠀⠀⠀⣿⡇⣯⣶⢄⠀⢢⡻⣦⡀⠀⠀
⠀⠀⠀⠀⠀⠘⢿⠼⢸⣋⠀⠀⡍⠻⣿⣦⠀
⠀⠀⠀⠀⠀⠀⠆⡇⢸⡠⣐⠥⡝⠶⠛⢿⠧
⠀⠀⠀⠀⢀⣠⣼⣧⣼⣷⣁⣒⣡⡴⠀⢸⡆
⠀⠀⠀⣪⠿⠗⠂⠀⠔⠊⠉⠉⠉⠉⢉⢢⠇            Welcome Back 
⠀⣠⠮⡷⠶⠿⠿⠭⠤⠤⣕⣲⣶⣶⠾⠋⠀
⠊⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        " , ConsoleColor.Blue);
    }

    static void ShowMenu()
    {
        Console.WriteLine("1 - Играть");
        Console.WriteLine("2 - Баланс");
        Console.WriteLine("3 - Выход");
        Console.Write("\n@root~> " , ConsoleColor.Cyan);
    }

    static void PlaySlots()
    {
        Console.Clear();
        ShowHeader();

        if (balance <= 0)
        {
            Console.WriteLine("Нет денег для игры!");
            Console.ReadKey();
            return;
        }

        Console.Write("Ваша ставка: " , ConsoleColor.DarkCyan);
        if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0 || bet > balance)
        {
            Console.WriteLine("Неверная ставка!");
            Thread.Sleep(1000);
            return;
        }

        Console.WriteLine("\nКрутим барабаны..." , ConsoleColor.DarkGreen);
        
        // бу корсатиш учун кичкина анимация
        for (int i = 0; i < 5; i++)
        {
            Console.Write("\r");
            Console.Write($"{symbols[random.Next(symbols.Length)]} {symbols[random.Next(symbols.Length)]} {symbols[random.Next(symbols.Length)]}");
            Thread.Sleep(2000);
        }

        // res 
        string a = symbols[random.Next(symbols.Length)];
        string b = symbols[random.Next(symbols.Length)];
        string c = symbols[random.Next(symbols.Length)];

        Console.WriteLine($"\n\nРезультат: {a} {b} {c}" , ConsoleColor.DarkRed);

        // proverka butta
        if (a == b && b == c)
        {
            int win = bet * 3;
            balance += win;
            Console.WriteLine($"🎉 ДЖЕКПОТ! Выигрыш: {win} монет!" , ConsoleColor.Cyan);
        }
        else if (a == b || b == c || a == c)
        {
            int win = bet;
            balance += win;
            Console.WriteLine($"👍 Выигрыш: {win} монет!" , ConsoleColor.DarkYellow);
        }
        else
        {
            balance -= bet;
            Console.WriteLine("💸 Проигрыш" , ConsoleColor.Magenta);
        }

        Console.WriteLine($"Новый баланс: {balance} монет");
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    static void ShowBalance()
    {
        Console.Clear();
        ShowHeader();
        Console.WriteLine($"У вас: {balance} монет" , ConsoleColor.DarkBlue);
        
        if (balance > 50)
            Console.WriteLine("Хорошая игра!");
        else if (balance > 10)
            Console.WriteLine("Продолжайте!");
        else
            Console.WriteLine("Осторожнее со ставками!");
        
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}
