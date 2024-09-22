using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVaga.DAO
{
    public class DAOConnection
    {
        public static void CreateDatabaseFile()
        {
            if (!File.Exists("./db.sqlite3"))
            {
                SQLiteConnection.CreateFile("db.sqlite3");
            }
        }

        public static SQLiteConnection GetConnection()
        {
            string connectionString = "Data Source=db.sqlite3";
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
