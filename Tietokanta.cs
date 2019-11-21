using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using projekti;

namespace Project
{
    class Tietokanta
    {
        // Yhdistetään tietokantaan
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "Grespost99";
        private const string DB = "Kannykkaliittymat";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;

        static private NpgsqlConnection connection;
        static private NpgsqlCommand GetAllLiittyma = null;
        static private NpgsqlCommand addComputer = null;

        // Yhdistetään tietokantaan
        public static void Connection()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        public static void StoreToSql()
        {
            //Tietokantaan lisääminen
        }
        public static void GetFromSql()
        {
            //Tietokannasta hakeminen
        }

        //Liittymien palauttaminen tietokannasta
        static public List<Liittyma> Get()
        {
            List<Liittyma> liittymalista = new List<Liittyma>();
            using (GetAllLiittyma = new NpgsqlCommand("SELECT computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM \"computer\" LEFT JOIN storagetype on computer.storagetypeid = storagetype.id LEFT JOIN computeruse on computer.useid = computeruse.id LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.id WHERE batterycapacity > 0;", connection))
            {
                GetAllLiittyma.Prepare();

                using (NpgsqlDataReader computers = GetAllLiittyma.ExecuteReader())

                    while (computers.Read())
                    {
                        liittymalista.Add(new Liittyma(computers.GetString(0), computers.GetInt32(1), computers.GetInt32(2), computers.GetInt32(3), computers.GetString(4), computers.GetString(5), computers.GetString(6)));
                        Console.WriteLine($" {computers.GetString(0)} {computers.GetInt32(1)} {computers.GetInt32(2)} {computers.GetInt32(3)} {computers.GetString(4)} {computers.GetString(5)} {computers.GetString(6)}");
                    }
                return liittymalista;
            }
        }

        
    }
}

    


