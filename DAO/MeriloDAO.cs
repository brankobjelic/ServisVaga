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
                merilo.Id = (long)reader[0];
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

        public static int UnesiMerilo(Merilo merilo)
        {
            int rowsAffected = 0;
            string sql = "INSERT INTO 'main'.'merilo'" +
                "('imalac', 'naziv', 'proizvodjac', 'tip', 'serijski_broj', 'godina_proizvodnje', 'sluzbena_oznaka', 'opseg merenja', 'najmanji podeok', 'klasa tacnosti') " +
                "VALUES(@imalac, '@naziv, @proizvodjac, @tip, @serijskiBroj, @godinaProizvodnje, @sluzbenaOznaka, @opsegMerenja, @najmanjiPodeok, @klasaTacnosti)";
            SQLiteConnection conn = DAOConnection.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO merilo" +
                "('imalac', 'naziv', 'proizvodjac', 'tip', 'serijski_broj', 'godina_proizvodnje', 'sluzbena_oznaka', 'opseg merenja', 'najmanji podeok', 'klasa tacnosti') " +
                "VALUES(@imalac, @naziv, @proizvodjac, @tip, @serijskiBroj, @godinaProizvodnje, @sluzbenaOznaka, @opsegMerenja, @najmanjiPodeok, @klasaTacnosti);", conn);
            cmd.Parameters.Add(new SQLiteParameter("imalac", merilo.Imalac.Id));
            cmd.Parameters.Add(new SQLiteParameter("naziv", merilo.Naziv));
            cmd.Parameters.Add(new SQLiteParameter("proizvodjac", merilo.Proizvodjac));
            cmd.Parameters.Add(new SQLiteParameter("tip", merilo.Tip));
            cmd.Parameters.Add(new SQLiteParameter("serijskiBroj", merilo.SerijskiBroj));
            cmd.Parameters.Add(new SQLiteParameter("godinaProizvodnje", merilo.GodinaProizvodnje));
            cmd.Parameters.Add(new SQLiteParameter("sluzbenaOznaka", merilo.SluzbenaOznaka));
            cmd.Parameters.Add(new SQLiteParameter("opsegMerenja", merilo.OpsegMerenja));
            cmd.Parameters.Add(new SQLiteParameter("najmanjiPodeok", merilo.NajmanjiPodeok));
            cmd.Parameters.Add(new SQLiteParameter("klasaTacnosti", merilo.KlasaTacnosti));
            rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }

        public static int ObrisiMerilo(long id)
        {
            SQLiteConnection conn = DAOConnection.GetConnection();
            string query = "DELETE from merilo where id=" + id;
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }

    }
}
