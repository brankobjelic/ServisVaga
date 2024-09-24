using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVaga.DAO
{
    public class KlijentDAO
    {
        public static List<Klijent> UcitajKlijente()
        {
            SQLiteConnection conn = DAOConnection.GetConnection();
            string query = "select * from klijent";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<Klijent> klijenti = new List<Klijent>();
            while (reader.Read())
            {
                Klijent klijent = new Klijent();
                klijent.Id = (int)(long)reader[0];
                klijent.Naziv = (string)reader[1];
                klijent.Mesto = (string)reader[2];
                klijent.UlicaIBroj = (string)reader[3];
                klijenti.Add(klijent);
            }
            reader.Close();
            conn.Close();
            return klijenti;
        }
    }
}
