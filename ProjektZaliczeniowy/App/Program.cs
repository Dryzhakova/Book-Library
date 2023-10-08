using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjektZaliczeniowy.Model;
using ProjektZaliczeniowy.View;
using ProjektZaliczeniowy.Repository;
using ProjektZaliczeniowy.Presenter;

namespace ProjektZaliczeniowy.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IBookRepository bookRepository = new BookRepository(); // Zast�p swoj� implementacj� BookRepository
            BookForm bookView = new BookForm(); // Tworzy instancj� klasy BookForm, kt�ra implementuje IBookView
            BookPresenter bookPresenter = new BookPresenter(bookView, bookRepository); // Tworzy instancj� klasy BookPresenter, przekazuj�c do niej widok i repozytorium

            Application.Run(bookView);
        }
    }
}
