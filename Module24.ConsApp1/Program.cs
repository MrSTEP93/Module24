using Module24.Lib;
using System;
using System.Data;
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
                
                var data = new DataTable();
                var db = new DbExecutor(connector);
                var tablename = "NetworkUser";

                Console.WriteLine($"Получаем данные таблицы {tablename} ...");
                data = db.SelectAll(tablename);
                Console.WriteLine("Отключаем БД!");
                connector.DisconnectAsync();

                PrintHeaders(data);
                PrintData(data);
            }
            else
            {
                Console.WriteLine($"Ошибка подключения: \n {result.Result.message}");
            }

            Console.Write("Press Enter for exit...");
            // Console.ReadKey();

        }

        public static void PrintHeaders(DataTable data)
        {
            foreach (DataColumn column in data.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }
            Console.WriteLine();
        }

        public static void PrintData(DataTable data)
        {
            foreach (DataRow row in data.Rows)
            {
                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write($"{cell}\t");
                }
                Console.WriteLine();
            }
        }
        
    }
}
