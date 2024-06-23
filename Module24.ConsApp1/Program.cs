using Microsoft.Data.SqlClient;
using Module24.Lib;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Module24.ConsApp1
{
    internal class Program
    {
        static Manager manager;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            manager = new Manager();
            manager.Connect();

            ShowCommands();
            Commands result;
            do
            {
                Console.Write("Type command: ");
                string command = Console.ReadLine();
                Enum.TryParse(command, true, out result);
                switch (result) {
                    case Commands.add:
                        AddUser();break;
                    case Commands.delete: 
                        DeleteUser(); break;
                    case Commands.update:
                        UpdateUser(); break;
                    case Commands.show:
                        manager.ShowData(); break;
                    default:
                        break;
                }
            }
            while (result != Commands.stop);
            
            manager.Disconnect();
            Console.Write("Press Enter for exit...");
            // Console.ReadKey();
        }

        public enum Commands
        {
            undef,
            stop,
            add,
            delete,
            update,
            show
        }

        static void ShowCommands()
        {
            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(Commands.stop + ": прекращение работы");
            Console.WriteLine(Commands.add + ": добавление данных");
            Console.WriteLine(Commands.delete + ": удаление данных");
            Console.WriteLine(Commands.update + ": обновление данных");
            Console.WriteLine(Commands.show + ": просмотр данных");
        }

        static void AddUser()
        {
            Console.Write("Type login of new user: ");
            string login = Console.ReadLine();
            Console.Write("Type name of new user: ");
            string name = Console.ReadLine();
            Console.WriteLine("Rows affected: " + manager.AddUser(login, name));

            manager.ShowData();
        }

        static void DeleteUser()
        {
            Console.Write("Type login for deleting (Ctrl+C for exit): ");
            Console.WriteLine("Rows affected: " + manager.DeleteUserByLogin(Console.ReadLine()));

            manager.ShowData();
        }

        static void UpdateUser()
        {
            Console.Write("Type login of the user being modifieduser: ");
            string login = Console.ReadLine();
            Console.Write("Type new name of user: ");
            string name = Console.ReadLine();
            Console.WriteLine("Rows affected: " + manager.UpdateUserByLogin(login, name));

            manager.ShowData();
        }
    }
}
