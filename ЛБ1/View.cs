using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ1
{
    class View
    {
        Controller controller = new();
        public void Menu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Вывод всех записей на экран");
            Console.WriteLine("2. Вывод записи по номеру");
            Console.WriteLine("3. Удаление записи (записей) из файла");
            Console.WriteLine("4. Добавление записи в файл");

            Console.Write("Выберите пункт меню: ");
            string choice = Console.ReadLine();
            string path = @"D:\Лабораторные\АИС\ЛБ1\ЛБ1\File.csv";

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    using (StreamReader sr = new StreamReader(path))
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Какую запись вывести?");
                    try
                    {
                        Console.WriteLine(controller.GetSeparate(path, Convert.ToInt16(Console.ReadLine()) - 1));
                        controller.ClearList();
                    }
                    catch
                    {
                        Console.WriteLine("Неверно введены данные.");
                        controller.ClearList();
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Какую запись удалить?");
                    try
                    {
                        controller.Delete(path, Convert.ToInt16(Console.ReadLine()) - 1);
                        Console.WriteLine("Запись удалена.");
                        controller.ClearList();
                    }
                    catch
                    {
                        Console.WriteLine("Неверно введены данные.");
                        controller.ClearList();
                    }
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Сколько записей добавить? ");
                    try
                    {
                        controller.AddToFile(path, Convert.ToInt16(Console.ReadLine()));
                        Console.WriteLine("Запись добавлена");
                    }
                    catch
                    {
                        Console.WriteLine("Неверно введены данные.");
                    }
                    controller.ClearList();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
