using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static List<Dictionary<string, double>> data = new List<Dictionary<string, double>>();

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
            Console.WriteLine();
        }

        static void Main()
        {   // D:\Dev\ex\try.txt
            Console.WriteLine(" Возможные операции:");
            Console.WriteLine(" Записать базу данных в файл -   нажать 1.");
            Console.WriteLine(" Считать базу данных в консоль - нажать 2.");
            //data.Add(new Dictionary<string, double>());

            int textInput = int.Parse(Console.ReadLine());

            if (textInput == 1)
            {
                SaveToFile();
            }

            if (textInput == 2)
            {
                LoadFromFile();
            }
            Console.ReadLine();

        }
    }
}
