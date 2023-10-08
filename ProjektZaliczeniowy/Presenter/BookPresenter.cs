using ProjektZaliczeniowy.Model;
using ProjektZaliczeniowy.View;
using ProjektZaliczeniowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy.Presenter
{
    public class BookPresenter
    {
        private IBookView view;
        private IBookRepository repository;
        private int bookId = -1;

        public BookPresenter(IBookView view, IBookRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.view.SearchBook += View_SearchBook;
            this.view.AddToMyLibrary += View_AddToMyLibrary;
            this.view.MyLibrary += View_LoadMyLibrary;
            this.view.LoadReviews += View_LoadReviews;
            this.view.AddReview += View_AddReview;

        }

        private void View_SearchBook()
        {
            try
            {
                Book book = repository.PobierzKsiazke(view.SearchTitle);
                Reviews recenzje = new Reviews();
                double ocena = recenzje.PobierzSredniaOcen(book.id);
                bookId = book.id;
                view.DisplayBook(book, ocena);
            } catch
            {
                view.ResetUI();
            }
        }
        
        private void View_AddReview()
        {
            try
            {
                Book book = repository.PobierzKsiazke(view.SearchTitle);
                Reviews recenzje = new Reviews();
                Review recenzja = view.GetReview();
                recenzja.idKsiazki = book.id;
                recenzje.DodajRecenzje(recenzja);
                view.DisplayBook(book, recenzje.PobierzSredniaOcen(book.id));
            }
            catch
            {
                view.DisplayError("Najpierw wyszukaj książkę");
            }
        }

        private void View_AddToMyLibrary()
        {
            try
            {
                Book book = repository.PobierzKsiazke(view.SearchTitle);
                MyLibrary library = new MyLibrary();
                library.UsunZBiblioteki(book.id);
                library.DodajDoBiblioteki(book, view.CzyPrzeczytane ? "przeczytane" : "doprzeczytania");
            } catch
            {
                view.DisplayError("Najpierw wyszukaj ksiązkę");
            }
        }

        private void View_LoadMyLibrary()
        {
            IMyLibrary myLibrary = new MyLibrary();
            MyLibraryForm libraryView = new MyLibraryForm();
            MyLibraryPresenter libraryPresenter = new MyLibraryPresenter(libraryView, myLibrary);

            libraryView.Show();
        }

        private void View_LoadReviews()
        {
            if(bookId != -1)
            {
                IReviews reviews = new Reviews();
                ReviewsForm reviewsView = new ReviewsForm();
                ReviewPresenter reviewsPresenter = new ReviewPresenter(reviewsView, reviews, bookId);

                reviewsView.Show();
            }
            else
            {
                view.DisplayError("Najpierw wyszukaj ksiązkę");
            }
        }

    }
}
