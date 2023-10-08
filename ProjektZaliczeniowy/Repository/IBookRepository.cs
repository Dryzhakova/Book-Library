using ProjektZaliczeniowy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy.Repository
{
    public interface IBookRepository
    {
        Book PobierzKsiazke(string title);
    }
}
