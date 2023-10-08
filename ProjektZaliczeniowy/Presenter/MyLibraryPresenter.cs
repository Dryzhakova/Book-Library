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
    public class MyLibraryPresenter
    {
        private ILibraryView view;
        private IMyLibrary myLibrary;

        public MyLibraryPresenter(ILibraryView view, IMyLibrary myLibrary)
        {
            this.view = view;
            this.myLibrary = myLibrary;
            this.view.DisplayLibrary += View_DisplayLibrary;
        }

        private void View_DisplayLibrary()
        {
            List<MyLibraryItem> doprzeczytania = myLibrary.PobierzWszystkieKsiazki("doprzeczytania");
            List<MyLibraryItem> przeczytane = myLibrary.PobierzWszystkieKsiazki("przeczytane");
            view.DisplayBooks(doprzeczytania, przeczytane);
        }
    }
}
