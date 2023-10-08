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
using ProjektZaliczeniowy.Repository;
using ProjektZaliczeniowy.Presenter;

namespace ProjektZaliczeniowy
{
    public partial class MyLibraryForm : Form, ILibraryView
    {
        public MyLibraryForm()
        {
            InitializeComponent();
        }

        public event Action DisplayLibrary;

        public void DisplayBooks(List<MyLibraryItem> ksiazkiDoPrzeczytania, List<MyLibraryItem> ksiazkiPrzeczytane)
        {
            foreach (var ksiazka in ksiazkiDoPrzeczytania)
            {
                listBox3.Items.Add($"{ksiazka.tytul}. Autor: {ksiazka.autor}");
            }

            foreach (var ksiazka in ksiazkiPrzeczytane)
            {
                listBox1.Items.Add($"{ksiazka.tytul}. Autor: {ksiazka.autor}");
            }
        }

        private void MyLibraryForm_Load(object sender, EventArgs e)
        {
            DisplayLibrary?.Invoke();
        }
    }
}


