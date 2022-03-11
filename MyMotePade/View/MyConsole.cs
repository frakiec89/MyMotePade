using System;

namespace MyNotePade.View
{
    internal class MyConsole
    {

        private Contrroller.RecordController records;

        public MyConsole(string path)
        {
            try
            {
                records = new Contrroller.RecordController(path);
                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Start()
        {
            PrintMenu();
            while (true)
            {
                try
                {
                    switch (GetStringConsole("Введите команду...").ToLower())
                    {
                        case "h": PrintMenu(); break;
                        case "g": GetContent(); break;
                        case "add": AddContent(); break;
                        case "exit": return;
                        default:
                            Console.WriteLine("неверная команда"); break;
                    }
                }
                catch (Exception ex) // ловим все  ошибки
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddContent()
        {
            string content = GetStringConsole("введите запись");
            string status = GetStringConsole("укажите статус  записи (например \"важно\")");
            records.Add(content, status);
            Console.WriteLine("запись добавлена");
            GetContent();
        }

        private void GetContent()
        {
            if(records.Records.Count ==0)
            {
                Console.WriteLine("Записей  еще нет");
                return;
            }

            foreach (var item in  records.Records)
            {
                Console.WriteLine(item);
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("h -список команд");
            Console.WriteLine("exit - Выход");
            Console.WriteLine("g -получить список записей");
            Console.WriteLine("add -добавить новую запись");
        }

        private string GetStringConsole(string v)
        {
            Console.WriteLine(v);
            var s = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("некорректный ввод");
                return GetStringConsole(v);
            }
            return s.TrimStart().TrimEnd();
        }
    }
}
