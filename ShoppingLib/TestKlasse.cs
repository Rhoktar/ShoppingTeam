using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ShoppingLib
{
    public class TestKlasse
    {
        public void DatenAbrufen()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Einkauf";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT Name,Kategorie FROM Objekt_Typen";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                dbCon.Close();
            }
        }
        public void DatenSchreiben()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Einkauf";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "INSERT INTO Objekt_Typen(Name, Standard_Menge, Kategorie) VALUES (@Name, @Standard_Menge, @Kategorie)";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.Parameters.AddWithValue("@Name", "Äpfel");
                cmd.Parameters.AddWithValue("@Standard_Menge", "5");
                cmd.Parameters.AddWithValue("@Kategorie", "Obst");
                cmd.ExecuteNonQuery();
                dbCon.Close();
            }
        }
    }
}
