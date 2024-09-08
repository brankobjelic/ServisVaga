using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVaga
{
    class Database
    {
        public SQLiteConnection connection;

        public Database()
        {
            if (!File.Exists("./db.sqlite3"))
            {
                SQLiteConnection.CreateFile("db.sqlite3");
            }

            connection = new SQLiteConnection("Data Source=db.sqlite3");
        }
    }
}
