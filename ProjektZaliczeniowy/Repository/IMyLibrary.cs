using ProjektZaliczeniowy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy.Repository
{
    public interface IMyLibrary
    {
        List<MyLibraryItem> PobierzWszystkieKsiazki(string tableName);
        void DodajDoBiblioteki(Book book, string gdzie);
        void UsunZBiblioteki(int id);
    }
}
