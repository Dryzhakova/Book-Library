using ProjektZaliczeniowy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy.Repository
{
    public interface IReviews
    {
        List<Review> PobierzRecenzje(int idKsiazki);
        double PobierzSredniaOcen(int idKsiazki);
        void DodajRecenzje(Review recenzja);
    }
}
