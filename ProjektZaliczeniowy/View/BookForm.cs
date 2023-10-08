using Org.BouncyCastle.Asn1.BC;
using ProjektZaliczeniowy.Model;
using ProjektZaliczeniowy.Presenter;
using ProjektZaliczeniowy.Repository;
using ProjektZaliczeniowy.View;
using System.Linq;

namespace ProjektZaliczeniowy
{
    public partial class BookForm : Form, IBookView
    {
        public BookForm()
        {
            InitializeComponent();
        }

        public event Action SearchBook;
        public event Action AddToMyLibrary;
        public event Action MyLibrary;
        public event Action LoadReviews;
        public event Action AddReview;
        public event Action<int> BookSelected;

        public string SearchTitle => txtSearchTitle.Text;

        public bool CzyPrzeczytane => radioButton1.Checked;

        public void DisplayBook(Book book, double ocena)
        {
            label5.Text = null;
            tytul.Text = book.tytul;
            autor.Text = book.imieAutora + " " + book.nazwiskoAutora;
            wydawnictwo.Text = book.wydawnictwo;
            label7.Text = "Autor:";
            label6.Text = "Wydawnictwo:";
            opis.Text = "Opis:";
            richTextBox2.Text = book.opis;

            label8.Text = Math.Round(ocena, 2).ToString();
            progressBar1.Value = (int)Math.Round(ocena * 10 * 2);

            BookSelected?.Invoke(book.id);
        }

        public Review GetReview()
        {
            Review review = new Review
            {
                idKsiazki = -1,
                ocena = trackBar1.Value,
                recenzja = richTextBox1.Text
            };

            return review;
        }

        public void ResetUI()
        {
            label5.Text = "Wygl¹da na to, ¿e nie mamy wyników dla Twojego wyszukiwania";
            tytul.Text = null;
            autor.Text = null;
            wydawnictwo.Text = null;
            label7.Text = null;
            label6.Text = null;
            opis.Text = null;
            richTextBox2.Text = null;

            label8.Text = "0";
            trackBar1.Value = 0;
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBook?.Invoke();
        }

        private void btnAddToMyLibrary_Click(object sender, EventArgs e)
        {
            AddToMyLibrary?.Invoke();
        }

        private void btnLoadMyLibrary_Click(object sender, EventArgs e)
        {
            MyLibrary?.Invoke();
        }

        private void btnLoadReviews_Click(object sender, EventArgs e)
        {
            LoadReviews?.Invoke();
        }

        private void btnAddReview_Click(object sender, EventArgs e)
        {
            AddReview?.Invoke();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}