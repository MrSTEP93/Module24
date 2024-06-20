using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module24.Lib
{
    public static class ConnectionString
    {
        // Server = адрес_сервера; Database=имя_базы_данных;User Id = логин; Password=пароль;

        public static string MsSqlConnection =>
            @"Server=31.210.218.202,9314; Initial Catalog=codeTesting; User Id=coder; Password=1993; TrustServerCertificate=True";
            //@"Server=.\SQLEXPRESS;Database=testing;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
