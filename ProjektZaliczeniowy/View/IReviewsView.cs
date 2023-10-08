using ProjektZaliczeniowy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy.View
{
    public interface IReviewsView
    {
        event Action DisplayReviews;
        void DisplayError(string message);
        void DisplayAllReviews(List<Review> reviews);
    }
}
