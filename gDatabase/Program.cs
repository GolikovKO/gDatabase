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

            int countOfLines = File.ReadAllLines(read).Length;

           // Console.WriteLine(countOfLines);

            using (StreamReader sr = new StreamReader(read, System.Text.Encoding.Default))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    for (int u = 0; u < countOfLines; u++)
                    {
                        string model = " ";
                        string price = " ";
                        string cpu = " ";

                        string text = " ";
                        string sentence = line;
                        int countOfSlash = 0;

                        for (int i = 6; i < sentence.Length; i++)
                        {
                            if (sentence[i] == '|')
                            {
                                countOfSlash += 1;

                                if (countOfSlash == 1)
                                {
                                    model = text;
                                    text = " ";
                                }

                                if (countOfSlash == 2)
                                {
                                    text = " ";
                                }

                                if (countOfSlash == 3)
                                {
                                    price = text;
                                    text = " ";
                                }

                                if (countOfSlash == 4)
                                {
                                    text = " ";
                                }

                                if (countOfSlash == 5)
                                {
                                    cpu = text;
                                    text = " ";
                                }
                            }
                            else
                            {
                                text += sentence[i];
                            }
                        }
                        data.Add(new Dictionary<string, string>());

                        data[u].Add("model", model);
                        data[u].Add("price", price);
                        data[u].Add("cpu", cpu);
                    }
                }
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
                        sw.Write(item.Key + "|");
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

                Console.WriteLine(" Success.");
            }
        }

        static void Output()
        {
            Console.WriteLine();

            for (int e = 0; e < data.Count; e++)
            {
                foreach (var item in data[e])
                {
                    Console.Write(item.Key + "|" + item.Value + "|");
                }
                Console.WriteLine();   
            }
        }

        static void CloseConsole()
        {
            Console.WriteLine(" Вы точно хотите выйти? (Y/N)");
            string answer = Console.ReadLine();

            if (answer == "Y") Environment.Exit(0);
        }

        static void Main()
        {   // D:\Dev\ex\try.txt
            // Вывод листа словарей в виде таблицы
            // Удаление словаря по индексу из листа
            // Изменение словаря по индексу из листа
            // Изменение хар-ки словаря по индексу
            // Добавление хар-ки в словарь
            // Удаление хар-ки из словаря
            Console.WriteLine(" Возможные операции:");
            Console.WriteLine(" Закрыть консоль              - нажать 0.");
            Console.WriteLine(" Записать базу данных в файл  - нажать 1.");
            Console.WriteLine(" Считать базу данных из файла - нажать 2.");
            Console.WriteLine(" Добавить новую запись в б/д  - нажать 3.");
            Console.WriteLine(" Отобразить б/д в консоль     - нажать 4.");

            while (true)

            {
                int textInput = int.Parse(Console.ReadLine());

                if (textInput == 0)
                {
                    CloseConsole();
                }

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

                if (textInput == 4)
                {
                    Output();
                }
            }
        }
    }
}
