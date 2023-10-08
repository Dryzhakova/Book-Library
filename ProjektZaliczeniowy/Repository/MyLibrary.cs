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
    public class MyLibrary : IMyLibrary
    {
        private string connectionString = "server=127.0.0.1;port=3306;user=root;password=2002;database=mojabiblioteka;";

        public List<MyLibraryItem> PobierzWszystkieKsiazki(string tableName)
        {
            var ksiazki = new List<MyLibraryItem>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM " + tableName;
                var cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new MyLibraryItem();
                        item.id = Convert.ToInt32(reader["id"]);
                        item.tytul = reader["tytul"].ToString();
                        item.autor = reader["autor"].ToString();

                        ksiazki.Add(item);
                    }
                }
            }

            return ksiazki;
        }

        public void DodajDoBiblioteki(Book book, string gdzie)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO " + gdzie + " (id, tytul, autor) VALUES (@id, @tytul, @autor)";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", book.id);
                cmd.Parameters.AddWithValue("@tytul", book.tytul);
                cmd.Parameters.AddWithValue("@autor", book.imieAutora + " " + book.nazwiskoAutora);

                cmd.ExecuteNonQuery();
            }
        }

        public void UsunZBiblioteki(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM przeczytane WHERE id = @id; DELETE FROM doprzeczytania WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
