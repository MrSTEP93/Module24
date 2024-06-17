using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Module24.Lib
{
    public class MainConnector
    {
        private SqlConnection connection;

        public async Task<(bool, string)> ConnectAsync()
        {
            (bool isSuccess, string message) result = (false, "not defined");
            try
            {
                connection = new SqlConnection(ConnectionString.MsSqlConnection);
                await connection.OpenAsync();
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.isSuccess = false;
            }

            return result;
        }

        public async void DisconnectAsync()
        {
            if (connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }
}
