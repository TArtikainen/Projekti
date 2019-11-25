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
        // Connection is private and gets opened in the constructor and used in all the db transactions
        static private NpgsqlConnection connection;
        static private NpgsqlCommand selectYritysLiittyma = null;
        static private NpgsqlCommand insertYritysLiittyma = null;
        static private NpgsqlCommand insertPerusLiittyma = null;
        static private NpgsqlCommand insertPrepaidLiittyma = null;


        // Konstruktori : Muodostaa yhteyden tietokantaan
        static Tietokanta()
        {
            try
            {
                connection = new NpgsqlConnection(CONNECTION_STRING);
                connection.Open(); // Here we open connection
            }
            catch (NpgsqlException ex)
            {
                throw new NpgsqlException($"Error in database connection ({ ex.Message }).");
            }

        }
        /*
        // GetAllLiittyma gets all the cars from the database into a generic list
        static public List<Liittyma> valitseYritysLiittyma()
        {
            List<Liittyma> list = new List<Liittyma>();
            using (selectYritysLiittyma = new NpgsqlCommand("SELECT * FROM yritysliittyma", connection))
            {
                selectYritysLiittyma.Prepare(); // Prepare the select query that gets all cars from the database

                using (NpgsqlDataReader results = selectYritysLiittyma.ExecuteReader())
                {
                    bool success;

                    while (results.Read())
                    {
                        list.Add(new Yritysliittyma(results.GetString(0), results.GetInt32(1), results.GetInt32(2)));
                    }
                }
            }

            return list;
        }
        */
        
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

        // LisaaPerusLiittyma lisää liittyman perus tietokantaan
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