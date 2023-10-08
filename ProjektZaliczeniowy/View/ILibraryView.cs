using ProjektZaliczeniowy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy.View
{
    public interface ILibraryView
    {
        event Action DisplayLibrary;
        void DisplayBooks(List<MyLibraryItem> ksiazkiDoPrzeczytania, List<MyLibraryItem> ksiazkiPrzeczytane);
    }
}
