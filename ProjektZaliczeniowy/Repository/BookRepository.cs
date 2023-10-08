using MySql.Data.MySqlClient;
using ProjektZaliczeniowy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy.Repository
{
    public class BookRepository : IBookRepository
    {
        private string connectionString = "server=127.0.0.1;port=3306;user=root;password=2002;database=ksiazki;";
        public Book PobierzKsiazke(string tytul)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT k.id_ksiazki, k.tytul, k.opis, a.imie, a.nazwisko, w.nazwa
                    FROM ksiazki k
                    INNER JOIN autorzy a ON k.id_autor = a.id_autorzy
                    INNER JOIN wydawnictwo w ON k.id_wydawnictwo = w.id_wydawnictwo
                    WHERE k.tytul = @tytul";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tytul", tytul);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id_ksiazki"]);
                        string tytulKsiazki = reader["tytul"].ToString();
                        string opisKsiazki = reader["opis"].ToString();
                        string imieAutora = reader["imie"].ToString();
                        string nazwiskoAutora = reader["nazwisko"].ToString();
                        string nazwaWydawnictwa = reader["nazwa"].ToString();

                        // Tworzenie nowego obiektu Book z przeczytanymi danymi
                        Book book = new Book
                        {
                            id = id,
                            tytul = tytulKsiazki,
                            imieAutora = imieAutora,
                            nazwiskoAutora = nazwiskoAutora,
                            opis = opisKsiazki,
                            wydawnictwo = nazwaWydawnictwa
                        };

                        return book;
                    }
                    else
                    {
                        throw new Exception("Książka o podanym tytule nie istnieje w bazie danych.");
                    }
                }
            }
        }
    }
}
