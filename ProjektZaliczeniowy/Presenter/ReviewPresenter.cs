using ProjektZaliczeniowy.Model;
using ProjektZaliczeniowy.View;
using ProjektZaliczeniowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ProjektZaliczeniowy.Presenter
{
    public class ReviewPresenter
    {
        private IReviewsView view;
        private IReviews reviews;
        private int bookId;

        public ReviewPresenter(IReviewsView view, IReviews reviews, int bookId)
        {
            this.view = view;
            this.reviews = reviews;
            this.bookId = bookId;
            this.view.DisplayReviews += View_DisplayReviews;
        }

        private void View_DisplayReviews()
        {

            try
            {
                List<Review> reviewsList = reviews.PobierzRecenzje(bookId);
                view.DisplayAllReviews(reviewsList);
            }
            catch
            {
                view.DisplayError("Nie wyszukano książki");
            }
        }
    }
}
