using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Module24.ConsApp1
{
    public class Assistant
    {
        public static List<string> GetColsNames(SqlDataReader reader)
        {
            var columnList = new List<string>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var name = reader.GetName(i);
                columnList.Add(name);
            }
            return columnList;
        }

        public static void PrintHeaders(DataTable data)
        {
            foreach (DataColumn column in data.Columns)
            {
                Console.Write($"{column.ColumnName}\t\t");
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
