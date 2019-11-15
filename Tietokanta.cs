using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.IO;
using projekti;

namespace Projekti
{
    class Tietokanta
    {
        
        private NpgsqlCommand insertLiittyma;

        void Test()
        {
            
        var connString = "Host=localhost;Username=postgres;Password=Grespost99;Database=Kannykkaliittymat";
    
        using (var conn = new NpgsqlConnection(connString))
        {
           conn.Open(); // Here we open connection
        
        // Here we define our SQL query
        using (var cmd = new NpgsqlCommand("SELECT * FROM \"Liittyma\"", conn))
        using (var reader = cmd.ExecuteReader())
        // Let's loop through all fetched rows
        while (reader.Read())
        // Let's get the string value in the field 1
        Console.WriteLine(reader.GetString(1));



                // AddCar adds a car to DB
                void AddLiittyma(Liittyma Liittyma)
                {
                    using (insertLiittyma = new NpgsqlCommand("INSERT INTO Liittyma(Operaattori, Liittymanopeus, Hinta) " +
                    "VALUES (@operaattori, @liittymanopeus, @hinta)", conn))
                    {
                        insertLiittyma.Parameters.AddWithValue("Operaattori", Liittyma.GetOperaattori());
                        insertLiittyma.Parameters.AddWithValue("Liittymanopeus", Liittyma.GetLiittymaNopeus());
                        insertLiittyma.Parameters.AddWithValue("Hinta", Liittyma.GetHinta());
                        insertLiittyma.ExecuteNonQuery();
                    }
                }
            }
        }
    }

}
    

