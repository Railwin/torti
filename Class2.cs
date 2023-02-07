using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tortiki_5_pract
{
        internal class Zakaz
        {
            public void MENU()
            {
                int Pos = 3;
                int MinPos = 3;
                int MaxPos = 8;
                int menu = 1;
                int index = 0;
                Class1 tortik = new Class1(0, 0, 0, 0, 0, 0, null);
                ConsoleKey key;

                while (true)
                {
                    tortik.AllPrice = tortik.FormPrice + tortik.SizePrice + tortik.TastePrice + tortik.DecorPrice + tortik.GlazePrice;
                    tortik.all_options = $"{tortik.form} - {tortik.FormPrice}\n          {tortik.size} - {tortik.SizePrice}\n          " +
                    $"{tortik.taste} - {tortik.TastePrice}\n          {tortik.glaze} - {tortik.GlazePrice}\n          {tortik.decor} - {tortik.DecorPrice}";
                    switch (menu)
                    {
                        case 1:
                            OsnMenu(tortik);
                            break;
                        case 2:
                            NeOsnovnoeMenu(prices, podmenu, index);
                            break;
                    }
                    WriteCursor(Pos);
                    key = Console.ReadKey(true).Key;
                    Pos = UpdateCursorPos(Pos, MaxPos, MinPos, key);
                    switch (menu)
                    {
                        case 1:
                            switch (key)
                            {
                                case ConsoleKey.Enter:
                                    if (Pos < 8)
                                    {
                                        menu = 2;
                                        MinPos = 1;
                                        index = Pos - 3;
                                        Pos = 3;
                                    }
                                    else if (Pos == 8)
                                    {
                                        SaveToOrder(tortik.all_options, tortik.AllPrice);
                                        Console.Clear();
                                        Console.WriteLine("Спасибо за заказ!");
                                        Console.WriteLine("Если хотите завершить выполнение программы нажмите escape");
                                        Console.WriteLine("Если хотите совершить еще один заказ нажмите любую клавишу");
                                        key = Console.ReadKey(true).Key;
                                        if (key == ConsoleKey.Escape)
                                        {
                                            Environment.Exit(0);
                                        }
                                        else
                                        {
                                            tortik = new Class1(0, 0, 0, 0, 0, 0, null);
                                            Pos = 3;
                                        }
                                    }
                                    break;
                                case ConsoleKey.Escape:
                                    Console.Clear();
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                        case 2:
                            switch (key)
                            {
                                case ConsoleKey.Enter:
                                    int position = Pos - 3;
                                    ViborTortika(prices, podmenu, index, position, tortik);
                                    menu = 1;
                                    Pos = 3;
                                    MinPos = 3;
                                    MaxPos = 9;
                                    break;
                                case ConsoleKey.Escape:
                                    menu = 1;
                                    Pos = 3;
                                    MinPos = 3;
                                    MaxPos = 8;
                                    break;
                            }
                            break;
                    }
                }
            }
            public static void OsnMenu(Class1 tortik)
            {
                Console.Clear();
                Console.WriteLine("Заказ тортиков на ваш выбор");
                Console.WriteLine("Выберите параметр");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("   Форма");
                Console.WriteLine("   Размер");
                Console.WriteLine("   Вкус");
                Console.WriteLine("   Глазурь");
                Console.WriteLine("   Декор");
                Console.WriteLine("   Конец заказа");
                Console.WriteLine("Если хотите выйти из меню нажмите esc");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Цена: {tortik.AllPrice}");
                Console.WriteLine($"Ваш торт: {tortik.all_options}");
            }
            private void NeOsnovnoeMenu(string[,] prices, string[,] podmenu, int index)
            {
                Console.Clear();
                Console.WriteLine("Для выхода нажмите ESC");
                Console.WriteLine("Выберите параметр тортика");
                Console.WriteLine("-----------------------------------------");
                for (int i = 0; i < 6; i++)
                {
                    if (podmenu[index, i] != "")
                    {
                        Console.WriteLine($"  {podmenu[index, i]} - {prices[index, i]} рублей");
                    }
                }

            }
            private int UpdateCursorPos(int Pos, int MaxPos, int MinPos, ConsoleKey key)
            {
                switch (key)
                {
                    case (ConsoleKey.UpArrow):
                        Pos--;
                        if (Pos < MinPos)
                        {
                            Pos = MinPos;
                        }
                        break;
                    case (ConsoleKey.DownArrow):
                        Pos++;
                        if (Pos > MaxPos)
                        {
                            Pos = MaxPos;
                        };
                        break;
                }
                return Pos;
            }
            private void WriteCursor(int Pos)
            {
                Console.SetCursorPosition(0, Pos);
                Console.WriteLine("-->");
            }
            private string[,] podmenu = new string[5, 6]
            {
            { " Квадрат", " Круг", " Трапеция", " Сердце", " Прямоугольник", "" },
            { " Маленький", " Средний", " Большой", " Огромный", " Супер огромный",""},
            { " Ванильный", " Шоколадный", " Карамельный", " Ягодный", " Кокосовый", ""},
            { " Шоколадная", " Ягодная", " Кремовая", " Ванильная", " Три шоколада", ""},
            { " Шоколад", " Крем", " Бизе", " Драже", " Ягоды", ""},
            };
            private string[,] prices = new string[5, 6]
            {
            { "100", "200", "400", "1400", "2540", ""},
            { "635", "250", "470", "1500", "7450", ""},
            { "745", "500", "120", "1700", "2390", ""},
            { "325", "320", "300", "1900", "1560", ""},
            { "105", "200", "700", "1000", "2680", ""},
            };
            public static void ViborTortika(string[,] prices, string[,] podmenu, int index, int position, Class1 tortik)
            {
                switch (index + 1)
                {
                    case 1:
                        tortik.form = podmenu[index, position];
                        tortik.FormPrice = Convert.ToInt32(prices[index, position]);
                        break;
                    case 2:
                        tortik.size = podmenu[index, position];
                        tortik.SizePrice = Convert.ToInt32(prices[index, position]);
                        break;
                    case 3:
                        tortik.taste = podmenu[index, position];
                        tortik.TastePrice = Convert.ToInt32(prices[index, position]);
                        break;
                    case 4:
                        tortik.glaze = podmenu[index, position];
                        tortik.GlazePrice = Convert.ToInt32(prices[index, position]);
                        break;
                    case 5:
                        tortik.decor = podmenu[index, position];
                        tortik.DecorPrice = Convert.ToInt32(prices[index, position]);
                        break;
                }
            }
            private static void SaveToOrder(string all_options, int AllPrice)
            {
                File.AppendAllText("C:\\Users\\79162\\Desktop\\История заказов.txt", $"\nЗаказ от: {DateTime.Now}\n      Заказ: {all_options}\n      Цена: {AllPrice}");
            }
        }
}
