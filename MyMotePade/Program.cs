using System;

namespace MyNotePade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Записная книжка";

            Console.WriteLine("...Моя записная книжка...");
            try
            {
                View.MyConsole myConsole = new View.MyConsole("content.bin");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("программа закончила свою работу ");
            Console.WriteLine("спасибо  что  вы  выбрали нашу  программу ");
            Console.WriteLine("..... СГК..продакшен....");
            Console.ReadLine();
        }
    }
}
