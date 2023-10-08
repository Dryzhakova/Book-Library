using MySql.Data.MySqlClient;
using ProjektZaliczeniowy.Model;
using ProjektZaliczeniowy.Repository;
using System;
using System.Collections.Generic;

public class Reviews : IReviews
{
    private string connectionString = "server=127.0.0.1;port=3306;user=root;password=2002;database=ksiazki;";

    public List<Review> PobierzRecenzje(int idKsiazki)
    {
        List<Review> recenzje = new List<Review>();

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            string query = @"
                SELECT r.id_recenzja, r.id_ksiazki, r.ocena, r.recenzja
                FROM recenzje r
                WHERE r.id_ksiazki = @idKsiazki";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idKsiazki", idKsiazki);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Review review = new Review
                    {
                        idKsiazki = Convert.ToInt32(reader["id_ksiazki"]),
                        ocena = Convert.ToInt32(reader["ocena"]),
                        recenzja = reader["recenzja"].ToString()
                    };
                    recenzje.Add(review);
                }
            }
        }

        return recenzje;
    }

    public void DodajRecenzje(Review recenzja)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            string query = "INSERT INTO recenzje (id_ksiazki, ocena, recenzja) VALUES (@idKsiazki, @ocena, @recenzja)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idKsiazki", recenzja.idKsiazki);
            cmd.Parameters.AddWithValue("@ocena", recenzja.ocena);
            cmd.Parameters.AddWithValue("@recenzja", recenzja.recenzja);

            cmd.ExecuteNonQuery();
        }
    }

    public double PobierzSredniaOcen(int idKsiazki)
    {
        double sredniaOcen = 0;

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            string query = @"
            SELECT AVG(r.ocena) as srednia
            FROM recenzje r
            WHERE r.id_ksiazki = @idKsiazki";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idKsiazki", idKsiazki);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    sredniaOcen = reader.IsDBNull(reader.GetOrdinal("srednia")) ? 0 : reader.GetDouble("srednia");
                }
            }
        }

        return sredniaOcen;
    }

}
