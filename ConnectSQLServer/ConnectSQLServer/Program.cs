using System;
using System.Data.SqlClient;

namespace ConnectSQLServer
{
    class DBSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }

    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"LEVINHPC\SQLEXPRESS";
            string database = "xtlab";
            string username = "sa";
            string password = "123";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.Read();
        }
    }
}
