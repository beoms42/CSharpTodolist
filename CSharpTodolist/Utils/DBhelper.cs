using CSharpTodolist.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CSharpTodolist.Utils
{
    public class DBhelper
    {
        private static string SERVER = "127.0.0.1";
        private static string UID = "login_yicho2";
        private static string PWD = "1234";
        private static string DATABASE = "db_yicho";

        private string CONNECTIONSTRING = $"server={SERVER};uid={UID};pwd={PWD};database={DATABASE};Encrypt=false;";

        private SqlConnection connection { get; set; }

        public SqlConnection GetConnection()
        {
            if (connection != null)
            {
                return connection;
            }
            else
            {
                return new SqlConnection(CONNECTIONSTRING);
            }
        }
    }
}
