using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace projekti;
{
    static class Tietokanta
    {
        // DB Connection details
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "Grespost99";
        private const string DB = "Kannykkaliittymat";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;
        // Connection is private and gets opened in the constructor and used in all the db transactions
        static private NpgsqlConnection connection;
        //static private NpgsqlCommand selectAllCars = null;
        static private NpgsqlCommand insertCar = null;

        // Constructor: creates the connection to the db
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

        // GetAllCars gets all the cars from the database into a generic list
        static public List<Liittyma> GetAllLiittyma()
        {
            List<Liittyma> list = new List<Liittyma>();
            using (selectAllCars = new NpgsqlCommand("SELECT * FROM cars", connection))
            {
                selectAllCars.Prepare(); // Prepare the select query that gets all cars from the database

                using (NpgsqlDataReader results = selectAllCars.ExecuteReader())
                {
                    bool success;

                    while (results.Read())
                    {
                        list.Add(new Car(results.GetString(0), results.GetString(1), results.GetString(2), results.GetInt32(3), out success));
                    }
                }
            }

            return list;
        }

        // AddCar adds a car to DB
        static public void LisaaLiittyma(Liittyma liittyma)
        {
            using (insertCar = new NpgsqlCommand("INSERT INTO Liittyma() " +
            "VALUES (@platenr, @colour, @model, @year)", connection))
            {
                insertCar.Parameters.AddWithValue("platenr", liittyma.GetPlateNumber());
                insertCar.Parameters.AddWithValue("colour", liittyma.GetColour());
                insertCar.Parameters.AddWithValue("model", liittyma.GetModel());
                insertCar.Parameters.AddWithValue("year", liittyma.GetYear());
                insertCar.ExecuteNonQuery();
            }
        }
    }
}