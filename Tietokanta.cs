using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace projekti
{
    static class Tietokanta
    {
        // Tietokannan yhdistämisen asetukset
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "Grespost99";
        private const string DB = "Kannykkaliittymat";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;
        // Yhteys on private ja se avataan konstruktorissa ja sitä käytetään kaikissa db-tapahtumissa
        static private NpgsqlConnection connection;
        static private NpgsqlCommand selectYritysLiittyma = null;
        static private NpgsqlCommand selectPerusLiittyma = null;
        static private NpgsqlCommand selectPrepaidLiittyma = null;
        static private NpgsqlCommand insertYritysLiittyma = null;
        static private NpgsqlCommand insertPerusLiittyma = null;
        static private NpgsqlCommand insertPrepaidLiittyma = null;


        // Konstruktori : Muodostaa yhteyden tietokantaan
        static Tietokanta()
        {
            try                                                   // try catch tietokannan yhdistämisen onnistumista varten
            {                                                               
                connection = new NpgsqlConnection(CONNECTION_STRING);
                connection.Open(); // Here we open connection
            }
            catch (NpgsqlException ex)
            {
                throw new NpgsqlException($"Error in database connection ({ ex.Message }).");
            }

        }
        
        // valitseYritysliittyma valitsee kaikki yritysliittymat tietokannasta
        static public List<Liittyma> valitseYritysLiittyma()
        {
            List<Liittyma> list = new List<Liittyma>();
            using (selectYritysLiittyma = new NpgsqlCommand("SELECT * FROM yritysliittyma", connection))
            {
                selectYritysLiittyma.Prepare(); // Valmistelee valitun kyselyn, joka saa kaikki yritysliittymat tietokannasta

                using (NpgsqlDataReader results = selectYritysLiittyma.ExecuteReader())
                {
                    while (results.Read())
                    {
                        list.Add(new Yritysliittyma(results.GetInt32(0), results.GetString(1), results.GetInt32(2), results.GetInt32(3)));
                    }
                }
            }

            return list;
        }

        // valitsePerusliittyma valitsee kaikki perusliittymat tietokannasta
        static public List<Liittyma> valitsePerusLiittyma()
        {
            List<Liittyma> list = new List<Liittyma>();
            using (selectPerusLiittyma = new NpgsqlCommand("SELECT * FROM perusliittyma", connection))
            {
                selectPerusLiittyma.Prepare(); // Valmistelee valitun kyselyn, joka saa kaikki perusliittymat tietokannasta

                using (NpgsqlDataReader results = selectPerusLiittyma.ExecuteReader())
                {
                    while (results.Read())
                    {
                        list.Add(new Perusliittyma(results.GetInt32(0), results.GetString(1), results.GetInt32(2), results.GetInt32(3)));
                    }
                }
            }

            return list;
        }

        // valitsePrepaidliittyma valitsee kaikki prepaidliittymat tietokannasta
        static public List<Liittyma> valitsePrepaidLiittyma()
        {
            List<Liittyma> list = new List<Liittyma>();
            using (selectPrepaidLiittyma = new NpgsqlCommand("SELECT * FROM prepaidliittyma", connection))
            {
                selectPrepaidLiittyma.Prepare(); // Valmistelee valitun kyselyn, joka saa kaikki prepaidliittymat tietokannasta

                using (NpgsqlDataReader results = selectPrepaidLiittyma.ExecuteReader())
                {
                    while (results.Read())
                    {
                        list.Add(new Prepaidliittyma(results.GetInt32(0), results.GetString(1), results.GetInt32(2), results.GetInt32(3)));
                    }
                }
            }

            return list;
        }

        // LisaaYritysLiittyma lisää liittyman yritys tietokantaan
        static public void LisaaYritysLiittyma(Liittyma liittyma)
        {
            using (insertYritysLiittyma = new NpgsqlCommand("INSERT INTO yritysliittyma(puhelinnumero, operaattori, datanopeus, hinta)" +
            "VALUES (@puhelinnumero, @operaattori, @datanopeus, @hinta)", connection))
            {
                insertYritysLiittyma.Parameters.AddWithValue("@puhelinnumero", liittyma.GetRandomNumber());
                insertYritysLiittyma.Parameters.AddWithValue("@operaattori", liittyma.GetOperaattori());
                insertYritysLiittyma.Parameters.AddWithValue("@datanopeus", liittyma.GetLiittymaNopeus());
                insertYritysLiittyma.Parameters.AddWithValue("@hinta", liittyma.GetHinta());
                insertYritysLiittyma.ExecuteNonQuery();
            }
        }

        // LisaaPerusLiittyma lisää liittyman perusliittyman tietokantaan
        static public void LisaaPerusLiittyma(Liittyma liittyma)
        {
            using (insertPerusLiittyma = new NpgsqlCommand("INSERT INTO perusliittyma(puhelinnumero, operaattori, datanopeus, hinta)" +
            "VALUES (@puhelinnumero, @operaattori, @datanopeus, @hinta)", connection))
            {

                insertPerusLiittyma.Parameters.AddWithValue("@puhelinnumero", liittyma.GetRandomNumber());
                insertPerusLiittyma.Parameters.AddWithValue("@operaattori", liittyma.GetOperaattori());
                insertPerusLiittyma.Parameters.AddWithValue("@datanopeus", liittyma.GetLiittymaNopeus());
                insertPerusLiittyma.Parameters.AddWithValue("@hinta", liittyma.GetHinta());
                insertPerusLiittyma.ExecuteNonQuery();
            }
        }

        // LisaaPrepaidLiittyma lisää liittyman prepaid tietokantaan
        static public void LisaaPrepaidLiittyma(Liittyma liittyma)
        {
            using (insertPrepaidLiittyma = new NpgsqlCommand("INSERT INTO prepaidliittyma(puhelinnumero, operaattori, datanopeus, hinta)" +
            "VALUES (@puhelinnumero, @operaattori, @datanopeus, @hinta)", connection))
            {

                insertPrepaidLiittyma.Parameters.AddWithValue("@puhelinnumero", liittyma.GetRandomNumber());
                insertPrepaidLiittyma.Parameters.AddWithValue("@operaattori", liittyma.GetOperaattori());
                insertPrepaidLiittyma.Parameters.AddWithValue("@datanopeus", liittyma.GetLiittymaNopeus());
                insertPrepaidLiittyma.Parameters.AddWithValue("@hinta", liittyma.GetHinta());
                insertPrepaidLiittyma.ExecuteNonQuery();
            }
        }
}
}