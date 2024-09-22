using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVaga.DAO
{
    public class MeriloDAO
    {
        public static List<Merilo> UcitajMerila()
        {
            SQLiteConnection conn = DAOConnection.GetConnection();
            string query = "select * from merilo left join klijent";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<Merilo> merila = new List<Merilo>();
            while (reader.Read())
            {
                Merilo merilo = new Merilo();
                merilo.Naziv = (string)reader[2];
                merilo.Proizvodjac = (string)reader[3];
                merilo.Tip = (string)reader[4];
                merilo.SerijskiBroj = (string)reader[5];
                merilo.GodinaProizvodnje = (long)reader[6];
                merilo.SluzbenaOznaka = (string)reader[7];
                merilo.OpsegMerenja = (string)reader[8];
                merilo.NajmanjiPodeok = (string)reader[9];
                merilo.KlasaTacnosti = (string)reader[10];
                merilo.Imalac = new Klijent();
                merilo.Imalac.Naziv = (string)reader[12];
                merilo.Imalac.Mesto = (string)reader[13];
                merilo.Imalac.UlicaIBroj = (string)reader[14];
                merila.Add(merilo);
            }
            reader.Close();
            conn.Close();
            return merila;
        }

    }
}
