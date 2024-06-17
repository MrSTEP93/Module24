using Module24.Lib;
using System;
using System.Threading.Tasks;

namespace Module24.ConsApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Connecting to database...");
            var connector = new MainConnector();

            Task<(bool isSuccess, string message)> result = connector.ConnectAsync();

            if (result.Result.isSuccess)
            {
                Console.WriteLine("Подключено успешно!");
            }
            else
            {
                Console.WriteLine($"Ошибка подключения: \n {result.Result.message}");
            }

            Console.Write("Press Enter for exit...");
            // Console.ReadKey();

        }
    }
}
