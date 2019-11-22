using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using projekti;

namespace WS6_Cars_Object_Persistance
{
    static class CarQueries
    {
        // DB Connection 
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "Grespost99";
        private const string DB = "Kannykkaliittymat";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;
        // Connection is private and gets opened in the constructor and used in all the db transactions
        static private NpgsqlConnection connection;
        static private NpgsqlCommand selectAllLiittyma = null;
        static private NpgsqlCommand insertliittyma = null;

        // Constructor: creates the connection to the db
        static CarQueries()
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
        static public List<Liityma> GetAllCars()
        {
            List<Liittyma> list = new List<Liittyma>();
            using (selectAllCars = new NpgsqlCommand("SELECT * FROM liittyma", connection))
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
        static public void AddCar(Vehicle car)
        {
            using (insertCar = new NpgsqlCommand("INSERT INTO Liittyma(liittymanopeus, hinta) " +
            "VALUES (@liittymanopeus, @hinta)", connection))
            {
                insertCar.Parameters.AddWithValue("platenr", Liittyma.GetPlateNumber());
                insertCar.Parameters.AddWithValue("colour", Lii.GetColour());
                insertCar.Parameters.AddWithValue("model", car.GetModel());
                insertCar.Parameters.AddWithValue("year", car.GetYear());
                insertCar.ExecuteNonQuery();
            }
        }
    }
}