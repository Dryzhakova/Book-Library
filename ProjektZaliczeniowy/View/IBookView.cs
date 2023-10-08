using ProjektZaliczeniowy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy.View
{
    public interface IBookView
    {
        event Action SearchBook;
        event Action AddToMyLibrary;
        event Action MyLibrary;
        event Action LoadReviews;
        event Action AddReview;
        event Action<int> BookSelected;
        string SearchTitle { get; }
        bool CzyPrzeczytane { get; }
        Review GetReview();
        void DisplayBook(Book book, double ocena);
        void DisplayError(string message);
        void ResetUI();
    }
}
