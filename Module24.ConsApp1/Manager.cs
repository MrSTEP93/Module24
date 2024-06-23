using Module24.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module24.ConsApp1
{
    public class Manager
    {
        private MainConnector connector;
        private DbExecutor dbExecutor;
        private Table userTable;

        public Manager()
        {
            connector = new MainConnector();

            userTable = new Table
            {
                Name = "NetworkUser",
                ImportantField = "Login"
            };
            userTable.Fields.Add("Id");
            userTable.Fields.Add("Login");
            userTable.Fields.Add("Name");
        }

        public void Connect()
        {
            Task<(bool isSuccess, string message)> result = connector.ConnectAsync();

            if (result.Result.isSuccess)
            {
                Console.WriteLine("Подключено успешно!");

                dbExecutor = new DbExecutor(connector);
            }
            else
            {
                Console.WriteLine("Ошибка подключения: " + result.Result.message);
            }
        }

        public void Disconnect()
        {
            Console.WriteLine("Отключаем БД!");
            connector.DisconnectAsync();
        }

        public void ShowData()
        {
            var tablename = "NetworkUser";
            Console.WriteLine("Получаем данные таблицы " + tablename);

            var data = dbExecutor.SelectAll(tablename);
            Console.WriteLine($"Количество строк в {tablename}: {data.Rows.Count} \n");

            foreach (DataColumn column in data.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }
            Console.WriteLine();

            foreach (DataRow row in data.Rows)
            {
                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write($"{cell}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int UpdateUserByLogin(string value, string newvalue)
        {
            return dbExecutor.UpdateValueCommand(userTable.Name, userTable.ImportantField, value, userTable.Fields[2], newvalue);
        }

        public int DeleteUserByLogin(string value)
        {
            return dbExecutor.DeleteValueCommand(userTable.Name, userTable.ImportantField, value);
        }

        public int AddUser(string login, string name)
        {
            return dbExecutor.ExecProcedureAddUser(login, name);
        }
    }
}
