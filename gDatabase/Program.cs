using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

        static void LoadFromFile()
        {
            Console.WriteLine(" Считываем файл.");
            string read = @"D:\Dev\ex\try.txt";

            Thread.Sleep(1000);
            using (StreamReader sr = new StreamReader(read))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }

        static void SaveToFile()
        {
            Console.WriteLine(" Укажите путь сохранения файла - диск, папка, название файла .txt:");
            string save = Console.ReadLine(); // путь

            using (StreamWriter sw = new StreamWriter(save, false, System.Text.Encoding.Default))
            {
                foreach (var dic in data)
                {
                    foreach (var item in dic)
                    {
                        sw.Write(item.Key   + "|");
                        sw.Write(item.Value + "|");
                    }
                    sw.WriteLine();   
                }
            }
        }

        static void MakeNewDic()
        {
            Console.WriteLine(" Сколько позиций добавить?");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                data.Add(new Dictionary<string, string>());

                Console.WriteLine(" Имя модели:");
                string model = Console.ReadLine();

                Console.WriteLine(" Цена:");
                string price = Console.ReadLine();

                Console.WriteLine(" Процессор:");
                string cpu = Console.ReadLine();

                data[i].Add("model", model);
                data[i].Add("price", price);
                data[i].Add("cpu", cpu);              
            }

            Console.WriteLine();

            for (int e = 0; e < count; e++)
            {
                foreach (var item in data[e])
                {
                    Console.Write(item.Key + item.Value);
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {                                               // D:\Dev\ex\try.txt
            Console.WriteLine(" Возможные операции:");
            Console.WriteLine(" Записать базу данных в файл  - нажать 1.");
            Console.WriteLine(" Считать базу данных из файла - нажать 2.");
            Console.WriteLine(" Добавить новую запись в б/д  - нажать 3.");

            int textInput = int.Parse(Console.ReadLine());

            if (textInput == 1)
            {
                SaveToFile();
            }

            if (textInput == 2)
            {
                LoadFromFile();
            }

            if (textInput == 3)
            {
                MakeNewDic();
            }

        }
    }
}
