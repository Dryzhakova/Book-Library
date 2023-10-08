using ProjektZaliczeniowy.View;
using ProjektZaliczeniowy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektZaliczeniowy
{
    public partial class ReviewsForm : Form, IReviewsView
    {
        public ReviewsForm()
        {
            InitializeComponent();
        }

        public event Action DisplayReviews;

        public void DisplayAllReviews(List<Review> recenzje)
        {
            foreach (var recenzja in recenzje)
            {
                opinie.Items.Add($"{recenzja.ocena} - {recenzja.recenzja}");
            }
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ReviewsForm_Load(object sender, EventArgs e)
        {
            DisplayReviews?.Invoke();
        }
    }
}

/*
 
 using System.Linq;

namespace ProjektZaliczeniowy
{
    public partial class BookForm : Form
    {

        public BookForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (opis.Text == null || opis.Text == "")
            {
                MessageBox.Show("Nie wyszukano książki", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {
                BazaDanych bazaDanych = new BazaDanych();
                MojaBiblioteka mojaBiblioteka = new MojaBiblioteka();
                var ksiazka = bazaDanych.PobierzKsiazke(textBox1.Text);
                if (radioButton1.Checked)
                {
                    mojaBiblioteka.DodajPrzeczytana(ksiazka.tytul, ksiazka.imieAutora + ksiazka.nazwiskoAutora);
                }
                else if (radioButton2.Checked)
                {
                    mojaBiblioteka.DodajDoPrzeczytania(ksiazka.tytul, ksiazka.imieAutora + ksiazka.nazwiskoAutora);
                }
                else
                {
                    MessageBox.Show("Nie wybrano pozycji", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Konto_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((label5.Text == ""&&opis.Text==null)||(label5.Text == "Wygląda na to, że nie mamy wyników dla Twojego wyszukiwania "))
            {
                MessageBox.Show("Nie wyszukano książki", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (trackBar1.Value == 0)
                {
                    MessageBox.Show("Wartość gwiazdek jest pusta", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BazaRecenzje recenzjeBaza = new BazaRecenzje();
                    recenzjeBaza.DodajRecenzje(textBox1.Text, trackBar1.Value, richTextBox1.Text);
                    List<(int ocena, string recenzja)> recenzje = recenzjeBaza.PobierzRecenzjePoTytuleKsiazki(textBox1.Text);
                    if (recenzje.Count > 0)
                    {
                        float sredniaOcen = (float)recenzje.Average(recenzja => recenzja.ocena);

                        progressBar1.Value = 60 + 2 * (int)Math.Round(sredniaOcen);
                        label8.Text = sredniaOcen.ToString();
                    }
                    else
                    {
                        // Ustaw wartości domyślne, jeżeli nie ma recenzji
                        progressBar1.Value = 60;
                        label8.Text = "3";
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_21(object sender, EventArgs e)
        {
            Form dlg1 = new Form();
            dlg1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BazaDanych bazaDanych = new BazaDanych();
            try
            {
                var ksiazka = bazaDanych.PobierzKsiazke(textBox1.Text);
                
                label5.Text = null;
                tytul.Text = ksiazka.tytul;
                autor.Text = ksiazka.imieAutora+" "+ksiazka.nazwiskoAutora;
                wydawnictwo.Text = ksiazka.nazwaWydawnictwa;
                label7.Text = "Autor:";
                label6.Text = "Wydawnictwo:";
                opis.Text = "Opis:";
                richTextBox2.Text = ksiazka.opis;
                BazaRecenzje recenzjeBaza = new BazaRecenzje();
                List<(int ocena, string recenzja)> recenzje = recenzjeBaza.PobierzRecenzjePoTytuleKsiazki(textBox1.Text);
                if (recenzje.Count > 0)
                {
                    float sredniaOcen = (float)recenzje.Average(recenzja => recenzja.ocena);

                    progressBar1.Value = 60 + 2 * (int)Math.Round(sredniaOcen);
                    label8.Text = sredniaOcen.ToString();
                }
                else
                {
                    // Ustaw wartości domyślne, jeżeli nie ma recenzji
                    progressBar1.Value = 60;
                    label8.Text = "3";
                }
                //pictureBox1.Image = null;
            }
            catch 
            {
                label5.Text = "Wygląda na to, że nie mamy wyników dla Twojego wyszukiwania ";
                tytul.Text = null;
                autor.Text = null;
                wydawnictwo.Text = null;
                label6.Text = null;
                label7.Text = null;
                opis.Text = null;
                richTextBox2.Text = null;
                label8.Text = null;
                //pictureBox1.Image = null;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tytul_Click(object sender, EventArgs e)
        {
            

        }
    }
}
 */

/*
 using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class BazaRecenzje
{
    private string connectionString = "server=127.0.0.1;port=3306;user=root;password=2002;database=ksiazki;";

    public List<(int ocena, string recenzja)> PobierzRecenzjePoTytuleKsiazki(string tytulKsiazki)
    {
        List<(int ocena, string recenzja)> recenzje = new List<(int ocena, string recenzja)>();

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            string query = @"
                SELECT r.ocena, r.recenzja
                FROM recenzje r
                INNER JOIN ksiazki k ON r.id_ksiazki = k.id_ksiazki
                WHERE k.tytul = @tytulKsiazki";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@tytulKsiazki", tytulKsiazki);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int ocena = Convert.ToInt32(reader["ocena"]);
                    string recenzja = reader["recenzja"].ToString();
                    recenzje.Add((ocena, recenzja));
                }
            }
        }

        return recenzje;
    }

    public void DodajRecenzje(string tytulKsiazki, int ocena, string recenzja)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            // Pobranie id książki o danym tytule
            string queryGetId = "SELECT id_ksiazki FROM ksiazki WHERE tytul = @tytulKsiazki";
            MySqlCommand cmdGetId = new MySqlCommand(queryGetId, conn);
            cmdGetId.Parameters.AddWithValue("@tytulKsiazki", tytulKsiazki);

            int idKsiazki;

            using (MySqlDataReader reader = cmdGetId.ExecuteReader())
            {
                if (reader.Read())
                {
                    idKsiazki = Convert.ToInt32(reader["id_ksiazki"]);
                }
                else
                {
                    throw new Exception("Książka o podanym tytule nie istnieje.");
                }
            }
            // Dodanie recenzji
            string queryAddReview = "INSERT INTO recenzje (id_ksiazki, ocena, recenzja) VALUES (@idKsiazki, @ocena, @recenzja)";
            MySqlCommand cmdAddReview = new MySqlCommand(queryAddReview, conn);
            cmdAddReview.Parameters.AddWithValue("@idKsiazki", idKsiazki);
            cmdAddReview.Parameters.AddWithValue("@ocena", ocena);
            cmdAddReview.Parameters.AddWithValue("@recenzja", recenzja);

            cmdAddReview.ExecuteNonQuery();
        }
    }

    public List<(int ocena, string recenzja)> PobierzWszystkieRecenzje()
    {
        List<(int ocena, string recenzja)> recenzje = new List<(int ocena, string recenzja)>();

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            string query = "SELECT ocena, recenzja FROM recenzje";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int ocena = Convert.ToInt32(reader["ocena"]);
                    string recenzja = reader["recenzja"].ToString();
                    recenzje.Add((ocena, recenzja));
                }
            }
        }

        return recenzje;
    }
}


 */
